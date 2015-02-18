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
                subparameter.selectedValueId = ko.observable(undefined);
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
                globalParameter.subparametersValues = {};
                data.Parameters.filter(function (parameter) {
                    return parameter.ParentId == globalParameter.Id;
                }).forEach(function(subparameter) {
                    globalParameter.subparametersValues[subparameter] = ko.computed(function () {
                        return parameterModel.subparameters[subparameter.Id].selectedValueId();
                    });
                });
                result[globalParameter.Id] = globalParameter;
            });
            return result;
        };
        // Посчитать нужную картинку по выбранным параметрам.
        var getResultImageUrl = function () {
         //   alert('Посчитали нужную картинку');
//            debugger;
            // Грязный хак.
            // TODO: избавиться.
            var globalParameterId = this;
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
                    return image.Url;
                }
            }
            return undefined;
        };
        // Посчитать x нужной картинки.
        var getResultImageX = function () {
            //   alert('Посчитали нужную картинку');
            //   debugger;
            // Грязный хак.
            // TODO: избавиться.
            var globalParameterId = this;
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
                    return parameterModel.designerImageBundles[i].Position[0].X;
                }
            }
            return undefined;
        };
        // Посчитать y нужной картинки.
        var getResultImageY = function () {
            //   alert('Посчитали нужную картинку');
//               debugger;
            // Грязный хак.
            // TODO: избавиться.
            var globalParameterId = this;
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
                    return parameterModel.designerImageBundles[i].Position[0].Y;
                }
            }
            return undefined;
        };
        var getResultImageBundles = function () {
            var resultImageBundles = {};
            var globalParametersKeys = Object.keys(parameterModel.globalParameters);
            for (var i = 0; i < globalParametersKeys.length; i++) {
                var globalParameter = parameterModel.globalParameters[globalParametersKeys[i]];
                resultImageBundles[globalParameter.Id] = {
                    url: ko.computed(getResultImageUrl, globalParameter.Id),
                    x: ko.computed(getResultImageX, globalParameter.Id),
                    y: ko.computed(getResultImageY, globalParameter.Id)
                };
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
           // alert('Положили новое значение параметра.');
            parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().Id](parameterValue.Id);
            //
//            parameterModel.subparameters[parameterModel.currentEditingSubparameter().Id].selectedValueId(parameterValue.Id);
        };
        // выбрано ли это значение подпараметра
        parameterModel.isActiveSubparameterValue = function (subparameterValue) {
            return parameterModel.selectedParametersValues[parameterModel.currentEditingSubparameter().Id]() == subparameterValue.Id;
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



getGlobalPamResultImage = function (parameter) {
    var subparameters = parameterModel.subparameters.filter(function (e) {
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
           // debugger;
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