SetTitleMatchMode, RegEx
#IfWinActive .*Microsoft Visual Studio|JetPopupMenuView|ReSharper|dotPeek|PyCharm|Rider|Android Studio|.*GVIM|.*Visual Studio Code
/*
 Move any short cuts to here if you want them limited to certain programs, If you use Vim bindings in all kinds of things,
 It can be useful to have everything global.

For example https://chrome.google.com/webstore/detail/surfingkeys/  in chrome

*/
#IfWinActive
<!k::Send {Up}
<!j::Send {Down}
Capslock::Esc
