
var selected = "alert alert-dismissible alert-success option";
var unselected = "alert alert-dismissible alert-light option";

$(".OptionCorrect").change(function () {
    

    // Set standard class on all options
    $(".option").attr("class", unselected);
    $(".OptionCorrect").not(this).prop("checked", false);
    
    // Set success class on selected option and check checkbox
    $(this).parent().attr("class", selected);
});