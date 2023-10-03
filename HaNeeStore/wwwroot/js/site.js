// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".product-quantity input").on("change", function () {
    const value = $(this).val();
    const id = $(this).attr("id");
    
    if (!isNaN(value) && id) {
        $.ajax({
            type: "GET",
            url: `/Cart/UpdateCart/${id}?quantityString=${value}`,
            contentType: "application/json",
            success: function () {
                window.location.reload();
            },
            error: function () {
                console.log("error")
            }
        })
    }
})
