getDesigner = function (data) {
    var model = {};

    var getParameterModel = function () {
        var parameterModel = {};

        var getSubparameters = function () {
            var result = {};
            var subparameters = data.parameters.filter(function (e) {
                return e.parentId;
            });
            subparameters.forEach(function (subparameter) {
                result[subparameter.id] = subparameter;
            });
            return result;
        };
        var getGlobalParameters = function () {
            var result = {};
            var globalParameters = data.parameters.filter(function (e) {
                return !e.parentId;
            });
            globalParameters.forEach(function (globalParameter) {
                result[globalParameter.id] = globalParameter;
            });
            return result;
        };
        // Посчитать нужную картинку по выбранным параметрам.
        // TODO: придумать название получше.
        var getResultImage = function () {
            // Грязный хак. TODO: Избавиться. Или объяснить почему можно только так.
            var globalParameterId = this;
            var result = {};
            var subparameterIds = {};
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                if (subparameter.parentId === parseInt(globalParameterId)) {
                    subparameterIds[subparameter.id] = parameterModel.selectedParametersValueIds[subparameter.id]();
                }
            }
            for (i = 0; i < parameterModel.designerImageBundles.length; i++) {
                var isGoodImage = true;
                var image = parameterModel.designerImageBundles[i].designerImage;
                if (Object.keys(image.parameters).length !== Object.keys(subparameterIds).length) {
                    continue;
                }
                var imageParametersKeys = Object.keys(image.parameters);
                for (var j = 0; j < imageParametersKeys.length; j++) {
                    var key = imageParametersKeys[j];
                    var parameterValue = image.parameters[key];
                    if (subparameterIds[key] !== parameterValue) {
                        isGoodImage = false;
                    }
                }
                if (isGoodImage) {
                    result.url = image.url;
                    var designerImageBundle = parameterModel.designerImageBundles[i];
                    var designerImageBundlePositions = parameterModel.designerImageBundles[i].positions;
                    var isGoodPosition;
                    for (var j = 0; j < designerImageBundlePositions.length; j++) {
                        isGoodPosition = true;
                        var positionParameters = designerImageBundlePositions[j].parameters;
                        for (var k = 0; k < Object.keys(positionParameters).length; k++) {
                            var positionParametersKey = Object.keys(positionParameters)[k];
                            var positionParametersValue = positionParameters[positionParametersKey];
                            if (parameterModel.selectedParametersValueIds[positionParametersKey]() !== parseInt(positionParametersValue, 10)) {
                                isGoodPosition = false;
                            }
                        }
                        if (isGoodPosition) {
                            result.y = designerImageBundle.positions[j].y;
                            result.x = designerImageBundle.positions[j].x;
                            return result;
                        }
                    }
                }
            }
            return undefined;
        };
        var getResultImageBundles = function() {
            var resultImageBundles = {};
            var globalParametersKeys = Object.keys(parameterModel.globalParameters);
            for (var i = 0; i < globalParametersKeys.length; i++) {
                var globalParameter = parameterModel.globalParameters[globalParametersKeys[i]];
                resultImageBundles[globalParameter.id] = ko.computed(getResultImage, globalParameter.id);
            };
            return resultImageBundles;
        };
        var setEditingSubparameter = function (subparameterId) {
            var subparameter = parameterModel.currentAvailableSubparameters().filter(function (e) {
                return e.id == subparameterId;
            })[0];
            parameterModel.currentEditingSubparameter(subparameter);
        };
        // ищет подпараметры для параметра
        // Поганое название. TODO: Поменять название. Без комментария непонятно.
        var setAvailableSubparameters = function (globalParameterId) {
            parameterModel.currentAvailableSubparameters.removeAll();
            var subparameters = data.parameters.filter(function (e) {
                return e.parentId == globalParameterId;
            });
            parameterModel.currentAvailableSubparameters(subparameters);
            setEditingSubparameter(parameterModel.currentAvailableSubparameters()[0].id);
        };
        var setEditingParameter = function(globalParameterId) {
            var parameter = data.parameters.filter(function (e) {
                return e.id == globalParameterId;
            })[0];
            parameterModel.currentEditingGlobalParameter(parameter);
            setAvailableSubparameters(parameter.id);
        };
        var isFormParameterSelected = function() {
            var tmp = parameterModel.selectedParametersValueIds[musGround.const.formSubparameterId];
            return tmp && tmp();
        }

        parameterModel.isOverviewMode = ko.observable(true);
        parameterModel.isFormSelected = undefined;

        parameterModel.selectingGlobalParameter = ko.observable(true);
        parameterModel.selectedGlobalParameter = ko.observable(null);
        parameterModel.selectedSubparameter = ko.observable(null);

        parameterModel.currentEditingGlobalParameter = ko.observable();
        parameterModel.currentAvailableSubparameters = ko.observableArray(null);
        parameterModel.currentEditingSubparameter = ko.observable(null);
        parameterModel.selectedParametersValueIds = [];
        parameterModel.resultImageBundles = undefined;
        parameterModel.designerImageBundles = data.designerImageBundles;
        parameterModel.predefinedGuitars = data.predefinedGuitars;
        parameterModel.parameterArrows = data.parameterArrows;
        parameterModel.subparameters = getSubparameters();
        parameterModel.globalParameters = getGlobalParameters();
        
        parameterModel.generatePredefinedGuitar = function () {
            var formSubparameterValue = parameterModel.selectedParametersValueIds[musGround.const.formSubparameterId]();
            if (!formSubparameterValue) {
                return;
            }
            var predefinedGuitars = parameterModel.predefinedGuitars.filter(function (predefinedGuitar) {
                return predefinedGuitar.formId === formSubparameterValue;
            });
            var predefinedGuitar = predefinedGuitars[Math.floor(Math.random() * predefinedGuitars.length)];
            for (var i = 0; i < Object.keys(predefinedGuitar.parameterValues).length; i++) {
                var parameterId = Object.keys(predefinedGuitar.parameterValues)[i];
                var parameterValueId = predefinedGuitar.parameterValues[parameterId];
                parameterModel.selectedParametersValueIds[parameterId](parameterValueId);
            }
            parameterModel.selectedSubparameter(null);
        }
        parameterModel.editParameter = function (globalParameter) {
            setEditingParameter(globalParameter.id);
            parameterModel.isOverviewMode(false);
        };
        parameterModel.editSubarameter = function (subparameter) {
            setEditingSubparameter(subparameter.id);
        };
        parameterModel.goToOverview = function() {
            parameterModel.isOverviewMode(true);
        };
        parameterModel.setSubparameterValue = function (parameterValue) {
            var formWasSelected = parameterModel.isFormSelected();
            parameterModel.selectedParametersValueIds[parameterModel.selectedSubparameter().id](parameterValue.id);
            var formIsSelected = parameterModel.isFormSelected();
            if (!formWasSelected && formIsSelected) {
                parameterModel.generatePredefinedGuitar();
            }
            parameterModel.goToOverview();
        };
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedParametersValueIds[parameterModel.currentEditingSubparameter().id]() == subparameterValue.id;
        };
        parameterModel.isIncopatibleSubparameterValue = function (subparameterValue) {
            for (var i = 0; i < subparameterValue.incompatibleParameters.length; i++) {
                var incompatibleParameter = subparameterValue.incompatibleParameters[i];
                if (parameterModel.selectedParametersValueIds[incompatibleParameter.parameterId]() == incompatibleParameter.parameterValueId) {
                    return true;
                }
            }
            return false;
        };
        parameterModel.warningIncompatibleWithForm = function (formSubparameterValue) {
            var alertText = 'Форма корпуса ' + formSubparameterValue.name + ' несовместима со следующими параметрами\n';
            for (var i = 0; i < formSubparameterValue.incompatibleParameters.length; i++) {
                var incompatibleParameter = formSubparameterValue.incompatibleParameters[i];
                if (parameterModel.selectedParametersValueIds[incompatibleParameter.parameterId]() == incompatibleParameter.parameterValueId) {
                    var incompatibleSubparameter = parameterModel.subparameters[incompatibleParameter.parameterId];
                    var incompatibleSubparameterValueName = incompatibleSubparameter.parameterValues.filter(function(parameterValue) {
                        return parameterValue.id == incompatibleParameter.parameterValueId;
                    })[0].name;
                    for (var i = 0; i < Object.keys(parameterModel.globalParameters).length; i++) {
                        var globalParameter = parameterModel.globalParameters[Object.keys(parameterModel.globalParameters)[i]];
                        if (globalParameter.id == incompatibleSubparameter.parentId) {
                            var incompatibleGlobalParameterName = globalParameter.nameNominative;
                        }
                    }
                    alertText += incompatibleGlobalParameterName + ' ' + incompatibleSubparameter.nameGenitive + ' ' + incompatibleSubparameterValueName + ';\n';
                }
            }
            alertText += 'Сменить форму? Все параметры буду сброшены.';
            if (confirm(alertText)) {
                parameterModel.selectedParametersValueIds[musGround.const.formSubparameterId](undefined);
                parameterModel.setSubparameterValue(formSubparameterValue);
            } else {
                return;
            }
        }
        parameterModel.getSelectedValueName = function(subparameterId) {
            var parameterValue = parameterModel.subparameters[subparameterId].parameterValues.filter(function(parameterValue) {
                return parameterValue.id === parameterModel.selectedParametersValueIds[subparameterId]();
            })[0];
            return parameterValue ? parameterValue.name : undefined;
        };
        parameterModel.changeSelectedParameter = function (subparameter) {
            var globalParameterId;
            Object.keys(parameterModel.globalParameters).forEach(function (globalParameterKey) {
                if (subparameter.parentId == globalParameterKey) {
                    globalParameterId = globalParameterKey;
                }
            });
            setEditingParameter(globalParameterId);
            setEditingSubparameter(subparameter.id);
            parameterModel.isOverviewMode(false);
        };
        parameterModel.editFormParameter = function() {
            setEditingParameter(musGround.const.bodyParameterId);
            setEditingSubparameter(musGround.const.formSubparameterId);
            parameterModel.isOverviewMode(false);
        }
        parameterModel.globalparameterHasAnyValue = function (parameterId) {
            var globalparameterHasAnyValue = false;
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                if (subparameter.parentId == parameterId && parameterModel.selectedParametersValueIds[subparameter.id]()) {
                    globalparameterHasAnyValue = true;
                    break;
                }
            }
            return globalparameterHasAnyValue;
        };
        parameterModel.GetSubparametersOfGlobal = function(parameterId) {
            return data.parameters.filter(function (e) {
                return e.parentId == parameterId;
            });
        }
        parameterModel.getArrow = function (parameterId) {
            var parameterArrow;
            var parameterArrows = parameterModel.parameterArrows.filter(function (parameterArrow) {
                return parameterArrow.parameterId == parameterId;
            });
            if (parameterArrows.length === 1) {
                parameterArrow = parameterArrows[0];
            } else {
                parameterArrow = parameterArrows.filter(function (parameterArrow) {
                    return parameterArrow.formId === parameterModel.selectedParametersValueIds[musGround.const.formSubparameterId]();
                })[0];
                if (!parameterArrow) {
                    parameterArrow = parameterArrows.filter(function (parameterArrow) {
                        return !parameterArrow.formId;
                    })[0];
                }
            }
            return parameterArrow;
        }

        ////
        parameterModel.selectGlobalParameter = function (globalParameterId) {
            parameterModel.selectedGlobalParameter(parameterModel.globalParameters[globalParameterId]);
            setAvailableSubparameters(globalParameterId);
            parameterModel.selectingGlobalParameter(false);
        }

        parameterModel.selectSubparameter = function (subparameter) {
            parameterModel.selectedSubparameter(subparameter);
        }
        parameterModel.dropSelectedSubparameter = function() {
            parameterModel.selectedSubparameter(undefined);
        }
        parameterModel.dropSelectedGlobalParameter = function () {
            parameterModel.selectedSubparameter(undefined);
            parameterModel.selectedGlobalParameter(undefined);
            parameterModel.selectingGlobalParameter(true);
        }


        ////

        parameterModel.init = function() {
            setEditingParameter(data.parameters[0].id);
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                parameterModel.selectedParametersValueIds[subparameter.id] = ko.observable(undefined);
            }
            parameterModel.resultImageBundles = getResultImageBundles();
            parameterModel.isFormSelected = ko.computed(isFormParameterSelected);
            parameterModel.editFormParameter();


            //
            parameterModel.selectedSubparameter(parameterModel.subparameters[musGround.const.formSubparameterId]);
            //
        };


        parameterModel.init();
        return parameterModel;
    };

    model.parameterModel = getParameterModel();

    return model;
};