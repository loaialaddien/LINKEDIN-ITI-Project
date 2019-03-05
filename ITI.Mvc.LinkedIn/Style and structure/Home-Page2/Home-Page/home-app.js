var message_menu = document.getElementById("message-body");
var message_btn = document.getElementById("messege-btn");
var isnotcollapsed=false ;
message_btn.addEventListener("click",check);

function check() {
    if(isnotcollapsed)
    {
        collapse();
    }
    else
    {
        expand();
    }
};

function collapse() {
    message_menu.style.transition="300ms";
    message_menu.style.height="0";
    isnotcollapsed=false;
};
function expand() {
    message_menu.style.transition="300ms";
        message_menu.style.height="300px";
        isnotcollapsed=true;
}




// var add_comment_input = document.getElementById("add-comment-field");
// var add_comment_btn =document.getElementById("add-comment-btn");
// hideCommentBtn();
// function hideCommentBtn() 
// {
//     if (add_comment_input == "") {
//         add_comment_btn.classList.add("hidden");
//     }
//     else{
//         add_comment_btn.classList.remove("hidden");
//     }    
// }

var comment_unit = document.getElementById("comment-units-container");
comment_unit.classList.add("hidden");
var comment_list_btn =document.getElementById("show-comments-list-btn");
comment_list_btn.addEventListener("click",hideCommentsList)

function hideCommentsList() {
    comment_unit.classList.remove("hidden");
    comment_unit.style.transition="300ms";
    
}
$("#add-comment-field").val();