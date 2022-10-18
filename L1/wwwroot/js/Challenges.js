
$(".option").on("click", function () {

    
    // Set standard class on all options
    $(".option").attr("class", "alert alert-dismissible alert-light option");
    $(".OptionCorrect").prop("checked", false);

    // Set success class on selected option and check checkbox
    $(this).attr("class", "alert alert-dismissible alert-success option");
    $(this).find(".OptionCorrect").prop("checked", true);
});