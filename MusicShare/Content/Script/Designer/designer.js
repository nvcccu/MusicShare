getDesigner = function(name, forms, colors, formsWithColor) {
    var model = {};
  
    var getChooseInstrumentModel = function() {
        var model = {};

        return model;
    };

    var getSubparameter = function(name, values) {
        var subparameter = {};
        subparameter.name = name;
        subparameter.selectedId = 0;
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
                name: value.Image,
                subparameterIds: {
                    formId: value.FormId,
                    colorId: value.ColorId
                }
            });
        }
        return images;
    };
    var getSubparameterNavigationModel = function () {
        var model = {};
        model.parameters = [];
        var formParameter = {};
        formParameter.name = name;
        formParameter.subparameters = [];
        var form_forms = getSubparameter("Форма", forms);
        var form_colors = getSubparameter("Цвет", colors);
        formParameter.subparameters.push(form_forms);
        formParameter.subparameters.push(form_colors);
        formParameter.images = getFormImages(formsWithColor);
        model.parameters.push(formParameter);
        return model;
    };

    model.chooseInstrumentModel = getChooseInstrumentModel();
    model.subparameterNavigationModel = getSubparameterNavigationModel();

    return model;
};