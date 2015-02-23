getDesigner = function (data) {
    var model = {};

    var getParameterModel = function () {
        var parameterModel = {};

        var getSubparameters = function () {
            var result = {};
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId;
            });
            subparameters.forEach(function (subparameter) {
                result[subparameter.Id] = subparameter;
            });
            return result;
        };
        var getGlobalParameters = function () {
            var result = {};
            var globalParameters = data.Parameters.filter(function (e) {
                return !e.ParentId;
            });
            globalParameters.forEach(function (globalParameter) {
                result[globalParameter.Id] = globalParameter;
            });
            return result;
        };
        // Посчитать нужную картинку по выбранным параметрам.
        var getResultImage = function () {
            // Грязный хак.
            // TODO: избавиться.
            var globalParameterId = this;
            var result = {};
            var subparameterIds = {};
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                if (subparameter.ParentId === parseInt(globalParameterId)) {
                    subparameterIds[subparameter.Id] = parameterModel.selectedParametersValues[subparameter.Id]();
                }
            }
            for (i = 0; i < parameterModel.designerImageBundles.length; i++) {
                var isGoodImage = true;
                var image = parameterModel.designerImageBundles[i].DesignerImage;
                if (Object.keys(image.Parameters).length !== Object.keys(subparameterIds).length) {
                    continue;
                }
                var imageParametersKeys = Object.keys(image.Parameters);
                for (var j = 0; j < imageParametersKeys.length; j++) {
                    var key = imageParametersKeys[j];
                    var parameterValue = image.Parameters[key];
                    if (subparameterIds[key] !== parameterValue) {
                        isGoodImage = false;
                    }
                }
                if (isGoodImage) {
                    result.url = image.Url;
                    var designerImageBundle = parameterModel.designerImageBundles[i];
                    var designerImageBundlePositions = parameterModel.designerImageBundles[i].Positions;
                    var isGoodPosition;
                    for (var j = 0; j < designerImageBundlePositions.length; j++) {
                        isGoodPosition = true;
                        var positionParameters = designerImageBundlePositions[j].Parameters;
                        for (var k = 0; k < Object.keys(positionParameters).length; k++) {
                            var positionParametersKey = Object.keys(positionParameters)[k];
                            var positionParametersValue = positionParameters[positionParametersKey];
                            if (parameterModel.selectedParametersValues[positionParametersKey]() !== parseInt(positionParametersValue, 10)) {
                                isGoodPosition = false;
                            }
                        }
                        if (isGoodPosition) {
                            result.y = designerImageBundle.Positions[j].Y;
                            result.x = designerImageBundle.Positions[j].X;
                            return result;
                        }
                    }
                }
            }
            return undefined;
        };
        var getResultImageBundles = function () {
            var resultImageBundles = {};
            var globalParametersKeys = Object.keys(parameterModel.globalParameters);
            for (var i = 0; i < globalParametersKeys.length; i++) {
                var globalParameter = parameterModel.globalParameters[globalParametersKeys[i]];
                resultImageBundles[globalParameter.Id] = ko.computed(getResultImage, globalParameter.Id);
            };
            return resultImageBundles;
        };

        parameterModel.isOverviewMode = ko.observable(true);
        parameterModel.currentEditingParameter = ko.observable();
        parameterModel.currentAvailableSubparameters = ko.observableArray(null);
        parameterModel.currentEditingSubparameter = ko.observable(null);
        parameterModel.selectedParametersValues = [];
        parameterModel.resultImageBundles = undefined;

        parameterModel.designerImageBundles = data.DesignerImageBundles;
        parameterModel.subparameters = getSubparameters();
        parameterModel.globalParameters = getGlobalParameters();
        
        
        // устанавливает настраиваемый параметр
        var setEditingParameter = function (globalParameterId) {
            var parameter = data.Parameters.filter(function(e) {
                return e.Id == globalParameterId;
            })[0];
            parameterModel.currentEditingParameter(parameter);
            setAvailableSubparameters(parameter.Id);
        };
        // ищет подпараметры для параметра
        var setAvailableSubparameters = function (globalParameterId) {
            parameterModel.currentAvailableSubparameters.removeAll();
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId == globalParameterId;
            });
            parameterModel.currentAvailableSubparameters(subparameters);
            setEditingSubparameter(parameterModel.currentAvailableSubparameters()[0].Id);
        };
        // устанавливает настраиваемый подпараметр
        var setEditingSubparameter = function (subparameterId) {
            var subparameter = parameterModel.currentAvailableSubparameters().filter(function (e) {
                return e.Id == subparameterId;
            })[0];
            parameterModel.currentEditingSubparameter(subparameter);
        };
        // клик по глобальному параметру
        parameterModel.editParameter = function (globalParameter) {
            setEditingParameter(globalParameter.Id);
            parameterModel.isOverviewMode(false);
        };
        // клик по подпараметру
        parameterModel.editSubarameter = function (subparameter) {
            setEditingSubparameter(subparameter.Id);
        };
        parameterModel.goToOverview = function() {
            parameterModel.isOverviewMode(true);
        };
        // клик по картинке для выбора значения подпараметра
        parameterModel.setSubparameterValue = function (parameterValue) {
            parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().Id](parameterValue.Id);
            parameterModel.goToOverview();
        };
        // выбрано ли это значение подпараметра
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().Id]() == subparameterValue.Id;
        };
        // доступно ли значение для выбора
        parameterModel.isIncopatibleSubparameterValue = function (subparameterValue) {
            for (var i = 0; i < subparameterValue.IncompatibleParameters.length; i++) {
                var incompatibleParameter = subparameterValue.IncompatibleParameters[i];
                if (parameterModel.selectedParametersValues[incompatibleParameter.ParameterId]() == incompatibleParameter.ParameterValueId) {
                    return true;
                }
            }
            return false;
        };
        parameterModel.getParentParameterName = function (parentId) {
            var globalParameter = parameterModel.globalParameters[Object.keys(parameterModel.globalParameters).filter(function (key) {
                return parameterModel.globalParameters[key].Id === parentId;
            })[0]];
            return globalParameter ? globalParameter.NameNominative : null;
        };
        parameterModel.getSelectedValueName = function(subparameterId) {
            var parameterValue = parameterModel.subparameters[subparameterId].ParameterValues.filter(function(parameterValue) {
                return parameterValue.Id === parameterModel.selectedParametersValues[subparameterId]();
            })[0];
            return parameterValue ? parameterValue.Name : "не выбрано";
        };
        parameterModel.dropSelectedParameter = function(subparameter) {
            parameterModel.selectedParametersValues[subparameter.Id](undefined);
        };

        parameterModel.init = function() {
            setEditingParameter(data.Parameters[0].Id);
            for (var i = 0; i < Object.keys(parameterModel.subparameters).length; i++) {
                var subparameter = parameterModel.subparameters[Object.keys(parameterModel.subparameters)[i]];
                parameterModel.selectedParametersValues[subparameter.Id] = ko.observable(undefined);
            }
            parameterModel.resultImageBundles = getResultImageBundles();
        };

        parameterModel.init();
        return parameterModel;
    };

    model.parameterModel = getParameterModel();

    return model;
};