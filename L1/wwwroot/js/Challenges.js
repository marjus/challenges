

$(".option").on("click", function () {
    $(".option").attr("class", "alert alert-dismissible alert-light option");
    $(this).attr("class", "alert alert-dismissible alert-success option");
    $("#selectedOptionId").val($(this).data("optionid"));
});