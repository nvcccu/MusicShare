getDesigner = function (data) {
    var model = {};

    var getParameterModel = function () {
        var model = {};

        var getGlobalParameters = function () {
            return data.Parameters.filter(function (e) {
                return !e.ParentId;
            });
        };
        var getSubparameters = function () {
            return data.Parameters.filter(function (e) {
                return e.ParentId;
            });
        };

        model.isOverviewMode = ko.observable(true);
        model.currentEditingParameter = ko.observable();
        model.currentAvailableSubparameters = ko.observableArray(null);
        model.currentEditingSubparameter = ko.observable(null);
        model.selectedParametersValues = ko.observableArray(null);
        model.globalParameters = getGlobalParameters();
        model.subparameters = getSubparameters();
        model.designerImageBundles = data.DesignerImageBundles;

        var setEditingParameter = function (parameterId) {
            var parameter = data.Parameters.filter(function(e) {
                return e.Id == parameterId;
            })[0];
            model.currentEditingParameter(parameter);
            model.setEditingSubparameters(parameter.Id);
        };
        var setEditingSubparameter = function (subparameterId) {
            var subparameter = model.currentAvailableSubparameters().filter(function (e) {
                return e.Id == subparameterId;
            })[0];
            model.currentEditingSubparameter(subparameter);
        };
        model.setEditingSubparameters = function (globalParameterId) {
            model.currentAvailableSubparameters.removeAll();
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId == globalParameterId;
            });
            model.currentAvailableSubparameters(subparameters);
            setEditingSubparameter(model.currentAvailableSubparameters()[0].Id);
        };
        model.editParameter = function (parameter) {
            setEditingParameter(parameter.Id);
            model.isOverviewMode(false);
        };
        model.editSubarameter = function (subparameter) {
            setEditingSubparameter(subparameter.Id);
        };
        model.goToOverview = function() {
            model.isOverviewMode(true);
        };
        model.setParameterValue = function (parameterValue) {
            model.selectedParametersValues()[model.currentEditingSubparameter().Id](parameterValue.Id);
        };
        model.isActiveSubparameterValue = function (subparameterValue) {
            return model.selectedParametersValues()[model.currentEditingSubparameter().Id]() == subparameterValue.Id;
        };
        model.getGlobalParamResultImage = function (parameter) {
            var subparameters = model.subparameters.filter(function(e) {
                return e.ParentId == parameter.Id;
            });
            var subparametersValues = [];
            subparameters.forEach(function (subparameter) {
                subparametersValues[subparameter.Id] = model.selectedParametersValues()[subparameter.Id]();
            });
            for (var i = 0; i < model.designerImageBundles.length; i++) {
                var isGoodImage = true;
                var image = model.designerImageBundles[i].DesignerImage;
                for (var j = 0; j < Object.keys(image.Parameters).length; j++) {
                    var key = Object.keys(image.Parameters)[j];
                    var parameterValue = image.Parameters[key];
                    if (subparametersValues[key] != parameterValue) {
                        isGoodImage = false;
                    }
                }
                if (isGoodImage) {
                    return image.Url;
                }
            }
//            var image = model.designerImageBundles.filter(function(dip) {
//                var res = false;
//                for (var key in dip.DesignerImage.Parameters) {
//                    if (model.selectedParametersValues()[key]() && model.selectedParametersValues()[key]() == dip.DesignerImage.Parameters[key]) {
//                        res = true;
//                    }
//                }
//                return res; 
//            })[0].DesignerImage;


            //DesignerImage
//            return image.Url;
            return '';
        };
        model.init = function() {
            setEditingParameter(data.Parameters[0].Id);
            for (var i = 0; i < model.subparameters.length; i++) {
                var subparameter = model.subparameters[i];
                model.selectedParametersValues()[subparameter.Id] = ko.observable(undefined);
            }
        };

        model.init();
        return model;
    };

    model.parameterModel = getParameterModel();

    return model;
};