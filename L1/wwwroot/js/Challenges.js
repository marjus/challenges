
$(".OptionCorrect").change(function () {
    
    // Set standard class on all options
    $(".option").attr("class", "alert alert-dismissible alert-light option");
    
    // Set success class on selected option and check checkbox
    $(this).attr("class", "alert alert-dismissible alert-success option");
});