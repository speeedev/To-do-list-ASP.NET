$(function () {
  $(".btn-close").click(function () {
    var btn = $(this);
    var id = btn.data("id");
    var action = btn.data("action");
    var url = "/" + action + "/" + id;

    // alert(url);
    $.ajax({
      type: "get",
      url: url,

      success: function (data) {
        // alert(data);
        btn.parent().remove();
      },
    });
  });
  $("li").click(function () {
    var btn = $(this);
    var id = btn.data("id");
    var action = btn.data("action");
    var url = "/" + action + "/" + id;

    // alert(url);
    $.ajax({
      type: "get",
      url: url,

      success: function (data) {
        // alert(data);
        if (data == "False") {
          btn.attr("class", "list-group-item list-group-item-success m-1");
        } else {
          btn.attr(
            "class",
            "list-group-item list-group-item-danger text-decoration-line-through m-1"
          );
        }
      },
    });
  });
});
