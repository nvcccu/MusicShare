getDesigner = function(name, forms, colors, formsWithColor, bridgeParamName, bridges) {
    var model = {};
  
    var getChooseInstrumentModel = function() {
        var model = {};

        return model;
    };

    var getSubparameter = function(name, values) {
        var subparameter = {};
        subparameter.name = name;
        subparameter.selectedId = ko.observable(0);
        subparameter.values = [];
        for (var i = 0; i < values.length; i++) {
            var value = values[i];
            subparameter.values.push({
                id: value.Id,
                name: value.Name,
                imagePreview: value.ImagePreview
            });
        }
        return subparameter;
    };
    var getFormImages = function(values) {
        var images = [];
        for (var i = 0; i <values.length; i++) {
            var value = values[i];
            images.push({
                id: value.Id,
                image: value.Image,
                subparameterIds: {
                    formId: value.FormId,
                    colorId: value.ColorId
                }
            });
        }
        return images;
    };
    var getBridgeImages = function (values) {
        var images = [];
        for (var i = 0; i < values.length; i++) {
            var value = values[i];
            images.push({
                id: value.Id,
                image: value.ImagePreview,
            });
        }
        return images;

    };
    var getSubparameterNavigationModel = function () {
        var model = {};

        model.isOverviewMode = ko.observable(true);
        model.currentEditingParameter = ko.observable(null);
        model.currentEditingSubparameter = ko.observable(null);
        
        var init = function() {
            model.parameters = [];
            var formParameter = {};
            formParameter.name = name;
            formParameter.subparameters = [];
            var form_forms = getSubparameter("Форма", forms);
            var form_colors = getSubparameter("Цвет", colors);
            formParameter.subparameters.push(form_forms);
            formParameter.subparameters.push(form_colors);
            formParameter.images = getFormImages(formsWithColor);
            formParameter.selectedImage = ko.computed(function() {
                var formId = formParameter.subparameters.filter(function(e) {
                    return e.name == "Форма";
                })[0].selectedId();
                var colorId = formParameter.subparameters.filter(function(e) {
                    return e.name == "Цвет";
                })[0].selectedId();
                if (formId == 0) {
                    return null;
                }
                return formParameter.images.filter(function(i) {
                    return i.subparameterIds.formId == formId && i.subparameterIds.colorId == colorId;
                })[0].image;
            });
            model.parameters.push(formParameter);
            model.currentEditingParameter(model.parameters[0]);
            model.currentEditingSubparameter(model.parameters[0].subparameters[0]);

            var bridgeParameter = {};
            bridgeParameter.name = bridgeParamName;
            bridgeParameter.subparameters = [];
            var bridge_bridge = getSubparameter("Бридж", bridges);
            bridgeParameter.subparameters.push(bridge_bridge);
            bridgeParameter.images = getBridgeImages(bridges);
            bridgeParameter.selectedImage = ko.computed(function () {
                var bridgeId = bridgeParameter.subparameters[0].selectedId();
                if (bridgeId == 0) {
                    return null;
                }
                return bridgeParameter.images.filter(function (i) {
                    return i.id == bridgeId;
                })[0].image;
            });
            model.parameters.push(bridgeParameter);
        };
        model.setEditParam = function(parameter) {
            model.currentEditingParameter(parameter);
            model.currentEditingSubparameter(parameter.subparameters[0]);
            model.isOverviewMode(false);
        };
        model.backToOverview = function() {
            model.isOverviewMode(true);
        };
        model.setEditSubparam = function (subparameter) {
            model.currentEditingSubparameter(subparameter);
        };
        model.selectSubparamValue = function (subparameterValue) {
            model.currentEditingSubparameter().selectedId(subparameterValue.id);
            model.isOverviewMode(true);
        };
//        model.getFormOverview = function () {
//            if (!model || !model.parameters || !model.isOverviewMode()) {
//                return null;
//            }
//            for (var i = 0; i < model.parameters.length; i++) {
//                if (model.parameters[i].name == "корпус") {
//                    var formParameter = model.parameters[i];
//                    break;
//                }
//            }
//            for (var i = 0; i < formParameter.subparameters.length; i++) {
//                if (formParameter.subparameters[i].name == "Форма") {
//                    var formSubparameter = formParameter.subparameters[i];
//                }
//                if (formParameter.subparameters[i].name == "Цвет") {
//                    var colorSubparameter = formParameter.subparameters[i];
//                }
//            }
//            var formId = formSubparameter.selectedId;
//            var colorId = colorSubparameter.selectedId;
//            return formParameter.images.filter(function(f) {
//                return f.subparameterIds.formId == formId && f.subparameterIds.colorId == colorId;
//            }).image;
//        };
        model.getFormOverview = function () {
           
            var formId = formSubparameter.selectedId;
            var colorId = colorSubparameter.selectedId;
            return formParameter.images.filter(function(f) {
                return f.subparameterIds.formId == formId && f.subparameterIds.colorId == colorId;
            }).image;
        };

        init();
        return model;
    };

    model.chooseInstrumentModel = getChooseInstrumentModel();
    model.subparameterNavigationModel = getSubparameterNavigationModel();

    return model;
};