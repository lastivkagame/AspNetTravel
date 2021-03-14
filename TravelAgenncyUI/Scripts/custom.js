function onSearch(e) {
    if (e.key === "Enter") {
        location.href = `/Tour/Index?search=${e.target.value}`;
    }
}

function onBtnSerch(e)
{
    location.href = `/Tour/Index?search=${inputsearch.value}`;
}
function ChoosenUrlImg(element) {
    var selector = $(element).data("input-to-show");
    var selector2 = $(element).data("input-to-hide");

    if ($(element).is(':checked')) {
        $(selector).hide();
        $(selector2).show();
    } else {
        $(selector).show();
        $(selector2).hide();
    }
}

function setFilter(element) {
    var type = $(element).data("type");
    var value = $(element).val();

    $("#toursContainer").load(`/Tour/Filter?type=${type}&value=${encodeURIComponent(value)}`);
}
