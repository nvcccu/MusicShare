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
        model.currentEditingSubparameters = ko.observableArray(null);
        model.globalParameters = getGlobalParameters();
        model.subparameters = getSubparameters();

        var setEditingParameter = function (parameter) {
            var editingParameter = data.Parameters.filter(function(e) {
                return e.Id == parameter.Id;
            })[0];
            model.currentEditingParameter(editingParameter);
            model.setEditingSubparameters(editingParameter.Id);
        };
        model.setEditingSubparameters = function (globalParameterId) {
            model.currentEditingSubparameters.removeAll();
            var subparameters = data.Parameters.filter(function (e) {
                return e.ParentId == globalParameterId;
            });
            model.currentEditingSubparameters(subparameters);
        };
        model.editParameter = function (parameterId) {
            setEditingParameter(parameterId);
            model.isOverviewMode(false);
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
        setEditingParameter(data.Parameters[0]);
        return model;
    };

    model.chooseInstrumentModel = getChooseInstrumentModel();
    model.parameterModel = getParameterModel();

    return model;
};