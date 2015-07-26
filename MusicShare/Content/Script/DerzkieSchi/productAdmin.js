getProductAdmin = function (data) {

    var model = {};

    var actualizeActiveProperties = function () {
        if (model.newProductType() == undefined) {
            return {};
        }
        var activeProperties = model.properties.filter(function (property) {
            return property.productTypeId === model.newProductType();
        });
        return activeProperties.map(function (property) {
            return {
                property: property,
                propertyValues: model.propertyValues.filter(function (propertyValue) {
                    return propertyValue.propertyId === property.id;
                })
            };
        });
    };

    model.newProductActive = ko.observable(true);
    model.productTypes = data.productTypes;
    model.properties = data.properties;
    model.propertyValues = data.propertyValues;

    model.newProductType = ko.observable(null);
    model.newProductImageUrl = ko.observable(null);
    model.activeProperties = ko.computed(actualizeActiveProperties);

    model.setNewProductActive = function() {
        model.newProductActive(true);
    };
    model.setNewProductInactive = function() {
        model.newProductActive(false);
    };

    return model;
}