getDesigner = function (data) {
    var model = {};
  
    var getChooseInstrumentModel = function() {
        var model = {};
        return model;
    };

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
        model.globalParameters = getGlobalParameters();
        model.subparameters = getSubparameters();

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
            if (subparameters.length == 0) {
                subparameters = data.Parameters.filter(function (e) {
                    return e.Id == globalParameterId;
                });
            }
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
        



        model.selectSubparamValue = function (subparameterValue) {
            model.currentEditingSubparameter().selectedId(subparameterValue.id);
            model.isOverviewMode(true);
        };

        model.getFormOverview = function () {
           
            var formId = formSubparameter.selectedId;
            var colorId = colorSubparameter.selectedId;
            return formParameter.images.filter(function(f) {
                return f.subparameterIds.formId == formId && f.subparameterIds.colorId == colorId;
            }).image;
        };
        setEditingParameter(data.Parameters[0].Id);
        return model;
    };

    model.chooseInstrumentModel = getChooseInstrumentModel();
    model.parameterModel = getParameterModel();

    return model;
};