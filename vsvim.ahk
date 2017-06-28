SetTitleMatchMode, RegEx
#IfWinActive .*Microsoft Visual Studio|JetPopupMenuView|ReSharper|dotPeek|PyCharm|Rider|Android Studio|.*GVIM|.*Visual Studio Code
<!k::Send {Up}
<!j::Send {Down}
#IfWinActive
Capslock::Esc
