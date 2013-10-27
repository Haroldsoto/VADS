function CascadingDDLViewModel() {
    this.models = ko.observableArray([]);
}

var objVM = new CascadingDDLViewModel();
ko.applyBindings(objVM);

function FetchModels() {
    var brandId = $("#ddlBrands").val();
    $.getJSON("/vehicle/GetStates/" + brandId, null, function (data) {
        objVM.models(data);
    });
}