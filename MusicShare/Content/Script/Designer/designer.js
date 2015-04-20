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
                    for (j = 0; j < designerImageBundlePositions.length; j++) {
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
                return e.id === subparameterId;
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
                return e.id === globalParameterId;
            })[0];
            setAvailableSubparameters(parameter.id);
        };
        var isFormParameterSelected = function() {
            var tmp = parameterModel.selectedParametersValueIds[musGround.const.formSubparameterId];
            return tmp && tmp();
        }

        parameterModel.isFormSelected = undefined;
        parameterModel.selectingGlobalParameter = ko.observable(true);
        parameterModel.selectedGlobalParameter = ko.observable(null);
        parameterModel.selectedSubparameter = ko.observable(null);
        parameterModel.selectedValue = ko.observable(null);
        parameterModel.currentAvailableSubparameters = ko.observableArray(null);
        parameterModel.currentEditingSubparameter = ko.observable(null);
        parameterModel.selectedParametersValueIds = [];
        parameterModel.resultImageBundles = undefined;
        parameterModel.designerImageBundles = data.designerImageBundles;
        parameterModel.predefinedGuitars = data.predefinedGuitars;
        parameterModel.subparameters = getSubparameters();
        parameterModel.globalParameters = getGlobalParameters();
        parameterModel.menuAnimateHelper = getMenuAnimateHelper();
        
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
        parameterModel.setSubparameterValue = function (parameterValue) {
            var formWasSelected = parameterModel.isFormSelected();
            parameterModel.selectedParametersValueIds[parameterModel.selectedSubparameter().id](parameterValue.id);
            var formIsSelected = parameterModel.isFormSelected();
            if (!formWasSelected && formIsSelected) {
                parameterModel.generatePredefinedGuitar();
            } else {
                parameterModel.selectedValue(parameterValue.id);
            }
        };
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedValue() === subparameterValue.id;
        };
        parameterModel.isIncopatibleSubparameterValue = function (subparameterValue) {
            for (var i = 0; i < subparameterValue.incompatibleParameters.length; i++) {
                var incompatibleParameter = subparameterValue.incompatibleParameters[i];
                if (parameterModel.selectedParametersValueIds[incompatibleParameter.parameterId]() === incompatibleParameter.parameterValueId) {
                    return true;
                }
            }
            return false;
        };
        // todo: разобраться с индексами в цикле.
        parameterModel.warningIncompatibleWithForm = function(formSubparameterValue) {
            var alertText = 'Форма корпуса ' + formSubparameterValue.name + ' несовместима со следующими параметрами:\n';
            for (var i = 0; i < formSubparameterValue.incompatibleParameters.length; i++) {
                var incompatibleParameter = formSubparameterValue.incompatibleParameters[i];
                if (parameterModel.selectedParametersValueIds[incompatibleParameter.parameterId]() == incompatibleParameter.parameterValueId) {
                    var incompatibleSubparameter = parameterModel.subparameters[incompatibleParameter.parameterId];
                    var incompatibleSubparameterValueName = incompatibleSubparameter.parameterValues.filter(function(parameterValue) {
                        return parameterValue.id === incompatibleParameter.parameterValueId;
                    })[0].name;
                    var incompatibleGlobalParameterName = undefined;
                    for (var j = 0; j < Object.keys(parameterModel.globalParameters).length; j++) {
                        var globalParameter = parameterModel.globalParameters[Object.keys(parameterModel.globalParameters)[j]];
                        if (globalParameter.id === incompatibleSubparameter.parentId) {
                            incompatibleGlobalParameterName = globalParameter.nameNominative;
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
        };
//        var afterSelectGlobalParameter = function (globalParameterId) {
//            return function() {
//                parameterModel.selectedGlobalParameter(parameterModel.globalParameters[globalParameterId]);
//                setAvailableSubparameters(globalParameterId);
//                parameterModel.selectingGlobalParameter(false);
//            }
//        };
        parameterModel.selectGlobalParameter = function (globalParameterId) {
            parameterModel.selectedGlobalParameter(parameterModel.globalParameters[globalParameterId]);
            setAvailableSubparameters(globalParameterId);
            parameterModel.selectingGlobalParameter(false);
//            parameterModel.menuAnimateHelper.onGlobalParameterChange(afterSelectGlobalParameter(globalParameterId));
        };
        parameterModel.selectSubparameter = function(subparameter) {
            parameterModel.selectedSubparameter(subparameter);
            parameterModel.selectedValue(parameterModel.selectedParametersValueIds[parameterModel.selectedSubparameter().id]());
        };
        parameterModel.gotoMainMenu = function() {
            parameterModel.selectedSubparameter(undefined);
            parameterModel.selectedValue(undefined);
            parameterModel.selectedGlobalParameter(undefined);
            parameterModel.selectingGlobalParameter(true);
        };
        parameterModel.gotoSubparametersMenu = function() {
            parameterModel.selectedSubparameter(undefined);
            parameterModel.selectedValue(undefined);
        };
        parameterModel.setPreviewValue = function (parameterValue) {
            parameterModel.selectedParametersValueIds[parameterModel.selectedSubparameter().id](parameterValue.id);
        };
        parameterModel.restoreActiveValue = function () {
            parameterModel.selectedParametersValueIds[parameterModel.selectedSubparameter().id](parameterModel.selectedValue());
        };
        parameterModel.init = function () {
            setEditingParameter(data.parameters[0].id);
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                parameterModel.selectedParametersValueIds[subparameter.id] = ko.observable(undefined);
            }
            parameterModel.resultImageBundles = getResultImageBundles();
            parameterModel.isFormSelected = ko.computed(isFormParameterSelected);
            parameterModel.selectedSubparameter(parameterModel.subparameters[musGround.const.formSubparameterId]);
        };

        parameterModel.init();
        return parameterModel;
    };

    model.parameterModel = getParameterModel();

    return model;
};