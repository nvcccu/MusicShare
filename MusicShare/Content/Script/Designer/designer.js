getDesigner = function (data) {
    var model = {};

    var getParameterModel = function () {
        var parameterModel = {};

        var getSubparameters = function () {
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId;
            });
            subparameters.forEach(function (subparameter) {
                subparameter.selectedValueId = ko.observable(undefined);
            });
            return subparameters;
        };
        var getGlobalParameters = function () {
            var globalParameters = data.Parameters.filter(function (e) {
                return !e.ParentId;
            });
            globalParameters.forEach(function (globalParameter) {
                globalParameter.subparametersValues = {};
                data.Parameters.filter(function (parameter) {
                    return parameter.ParentId == globalParameter.Id;
                }).forEach(function(subparameter) {
                    globalParameter.subparametersValues[subparameter] = ko.computed(function() {
                        return parameterModel.subparameters.filter(function(e) {
                            return e.Id == subparameter.Id;
                        })[0].selectedValueId();
                    });
                });
            });
            return globalParameters;
        };
        var getResultImageUrl = function() {
            var globalParameterId = this;
            //
            return '/ImgStore/FormWithColor/Stratocaster_Red.png';
        };
        var getResultImageBundles = function () {
            var resultImageBundles = {};
            for(var i = 0; i < Object.keys(parameterModel.globalParameters).length; i++) {
                var globalParameter = parameterModel.globalParameters[Object.keys(parameterModel.globalParameters)[i]];
                resultImageBundles[globalParameter.Id] = {
                    url: ko.computed(getResultImageUrl, globalParameter.Id),
                    x: ko.observable(undefined),
                    y: ko.observable(undefined)
                };
            };
            
        };

        parameterModel.isOverviewMode = ko.observable(true);
        parameterModel.currentEditingParameter = ko.observable();
        parameterModel.currentAvailableSubparameters = ko.observableArray(null);
        parameterModel.currentEditingSubparameter = ko.observable(null);
        parameterModel.selectedParametersValues = ko.observableArray(null);

        parameterModel.subparameters = getSubparameters();
        parameterModel.globalParameters = getGlobalParameters();
        parameterModel.resultImageBundles = getResultImageBundles();

        parameterModel.resultImagesWithPosition = ko.observableArray(null);
        parameterModel.designerImageBundles = data.DesignerImageBundles;
        parameterModel.resultImageBundles = {};

        var setEditingParameter = function (parameterId) {
            var parameter = data.Parameters.filter(function(e) {
                return e.Id == parameterId;
            })[0];
            parameterModel.currentEditingParameter(parameter);
            parameterModel.setEditingSubparameters(parameter.Id);
        };
        var setEditingSubparameter = function (subparameterId) {
            var subparameter = parameterModel.currentAvailableSubparameters().filter(function (e) {
                return e.Id == subparameterId;
            })[0];
            parameterModel.currentEditingSubparameter(subparameter);
        };
        parameterModel.setEditingSubparameters = function (globalParameterId) {
            parameterModel.currentAvailableSubparameters.removeAll();
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId == globalParameterId;
            });
            parameterModel.currentAvailableSubparameters(subparameters);
            setEditingSubparameter(parameterModel.currentAvailableSubparameters()[0].Id);
        };
        parameterModel.editParameter = function (parameter) {
            setEditingParameter(parameter.Id);
            parameterModel.isOverviewMode(false);
        };
        parameterModel.editSubarameter = function (subparameter) {
            setEditingSubparameter(subparameter.Id);
        };
        parameterModel.goToOverview = function() {
            parameterModel.isOverviewMode(true);
        };
        parameterModel.setParameterValue = function (parameterValue) {
            parameterModel.selectedParametersValues()[parameterModel.currentEditingSubparameter().Id](parameterValue.Id);

            //
            parameterModel.getGlobalParamResultImage(parameterModel.currentEditingParameter());
        };
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedParametersValues()[parameterModel.currentEditingSubparameter().Id]() == subparameterValue.Id;
        };
        parameterModel.getGlobalParamResultImage = function (parameter) {
            var subparameters = parameterModel.subparameters.filter(function(e) {
                return e.ParentId == parameter.Id;
            });
            var subparametersValues = [];
            subparameters.forEach(function (subparameter) {
                subparametersValues[subparameter.Id] = parameterModel.selectedParametersValues()[subparameter.Id]();
            });
            for (var i = 0; i < parameterModel.designerImageBundles.length; i++) {
                var isGoodImage = true;
                var image = parameterModel.designerImageBundles[i].DesignerImage;
                for (var j = 0; j < Object.keys(image.Parameters).length; j++) {
                    var key = Object.keys(image.Parameters)[j];
                    var parameterValue = image.Parameters[key];
                    if (subparametersValues[key] != parameterValue) {
                        isGoodImage = false;
                    }
                }
                if (isGoodImage) {
                    debugger;
                    var imageBundle = parameterModel.designerImageBundles[i];
                    parameterModel.resultImagesWithPosition()[parameter.Id] = {};
                    parameterModel.resultImagesWithPosition()[parameter.Id].url = image.Url;
                    parameterModel.resultImagesWithPosition()[parameter.Id].x = 0;
                    parameterModel.resultImagesWithPosition()[parameter.Id].y = 0;
                    for (j = 0; j < imageBundle.Position.length; j++) {
                        var position = imageBundle.Position[j];
                        var isGoodPosition = true;
                        for (var k = 0; k < Object.keys(position.Parameters).length; k++) {
                            var positionParameterKey = Object.keys(position.Parameters)[k];
                            var positionParameterValue = position.Parameters[positionParameterKey];
                            if (parameterModel.selectedParametersValues()[positionParameterKey]() != positionParameterValue) {
                                isGoodPosition = false;
                            }
                        }
                        if (isGoodPosition) {
                            parameterModel.resultImagesWithPosition()[parameter.Id].x = position.X;
                            parameterModel.resultImagesWithPosition()[parameter.Id].y = position.Y;
                            return;
                        }
                    }
                }
            }
            return;
        };
        parameterModel.getResultImagePosition = function() {
            
        };
        parameterModel.init = function() {
            setEditingParameter(data.Parameters[0].Id);
            for (var i = 0; i < parameterModel.subparameters.length; i++) {
                var subparameter = parameterModel.subparameters[i];
                parameterModel.selectedParametersValues()[subparameter.Id] = ko.observable(undefined);
            }
        };

        parameterModel.init();
        return parameterModel;
    };

    model.parameterModel = getParameterModel();

    return model;
};