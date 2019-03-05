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





