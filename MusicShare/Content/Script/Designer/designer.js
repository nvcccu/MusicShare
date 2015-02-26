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
                    subparameterIds[subparameter.id] = parameterModel.selectedParametersValues[subparameter.id]();
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
                            if (parameterModel.selectedParametersValues[positionParametersKey]() !== parseInt(positionParametersValue, 10)) {
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
            parameterModel.currentEditingParameter(parameter);
            setAvailableSubparameters(parameter.id);
        };
        var isFormParameterSelected = function() {
            var tmp = parameterModel.selectedParametersValues[musGround.const.formSubparameterId];
            return tmp && tmp();
        }

        parameterModel.isOverviewMode = ko.observable(true);
        parameterModel.isFormSelected = undefined;
        parameterModel.currentEditingParameter = ko.observable();
        parameterModel.currentAvailableSubparameters = ko.observableArray(null);
        parameterModel.currentEditingSubparameter = ko.observable(null);
        parameterModel.selectedParametersValues = [];
        parameterModel.resultImageBundles = undefined;
        parameterModel.designerImageBundles = data.designerImageBundles;
        parameterModel.predefinedGuitars = data.predefinedGuitars;
        parameterModel.subparameters = getSubparameters();
        parameterModel.globalParameters = getGlobalParameters();
        
        parameterModel.generatePredefinedGuitar = function () {
            var formSubparameterValue = parameterModel.selectedParametersValues[musGround.const.formSubparameterId]();
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
                parameterModel.selectedParametersValues[parameterId](parameterValueId);
            }
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
            parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().id](parameterValue.id);
            parameterModel.goToOverview();
        };
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().id]() == subparameterValue.id;
        };
        parameterModel.isIncopatibleSubparameterValue = function (subparameterValue) {
            for (var i = 0; i < subparameterValue.incompatibleParameters.length; i++) {
                var incompatibleParameter = subparameterValue.incompatibleParameters[i];
                if (parameterModel.selectedParametersValues[incompatibleParameter.parameterId]() == incompatibleParameter.parameterValueId) {
                    return true;
                }
            }
            return false;
        };
        parameterModel.getParentParameterName = function (parentId) {
            var globalParameter = parameterModel.globalParameters[Object.keys(parameterModel.globalParameters).filter(function (key) {
                return parameterModel.globalParameters[key].id === parentId;
            })[0]];
            return globalParameter ? globalParameter.nameNominative : null;
        };
        parameterModel.getSelectedValueName = function(subparameterId) {
            var parameterValue = parameterModel.subparameters[subparameterId].parameterValues.filter(function(parameterValue) {
                return parameterValue.id === parameterModel.selectedParametersValues[subparameterId]();
            })[0];
            // TODO: Выпилить. "не выбрано" должно быть в верстке.
            return parameterValue ? parameterValue.name : "не выбрано";
        };
        parameterModel.dropSelectedParameter = function(subparameter) {
            parameterModel.selectedParametersValues[subparameter.id](undefined);
        };
        parameterModel.editFormParameter = function() {
            setEditingParameter(musGround.const.bodyParameterId);
            setEditingSubparameter(musGround.const.formSubparameterId);
            parameterModel.isOverviewMode(false);
        }

        parameterModel.init = function() {
            setEditingParameter(data.parameters[0].id);
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                parameterModel.selectedParametersValues[subparameter.id] = ko.observable(undefined);
            }
            parameterModel.resultImageBundles = getResultImageBundles();
            parameterModel.isFormSelected = ko.computed(isFormParameterSelected);
            ko.computed(function () {
                if (!parameterModel.selectedParametersValues[musGround.const.colorSubparameterId]()) {
                    parameterModel.selectedParametersValues[musGround.const.colorSubparameterId](musGround.const.whiteColorSubparameterValueId);
                }
            });
        };


        parameterModel.init();
        return parameterModel;
    };

    model.parameterModel = getParameterModel();

    return model;
};