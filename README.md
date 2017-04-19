# VsVim + Resharper Guide with C# editing scenarios

Work in progress!  The guide highlights useful editing commands while programming using VsVim.  

Vims power comes from chaining combinations together, and while much of vim is well documented it is often hard to learn effective combo!

This guide ( currently ) assumes VsVim doesn't bind to any of the modifier keys ( like ctrl ) which leaves Resharpers bindings as default

## Changing Text


```cw```  - changes the word from the cusor to the end of the word

ciw - changes the entire worth that the cursor is on

cf<char> - changes text until you find the chararcter <char>, includes the find char

ct<char> - changes text until you find the charracter <char>, but don't include the char

c<n>f<char> -  same as previous cf but find the nth occurance of the char

c<n>t<char> -  same as previous ct but find the nth occurance of the char


r<char> - replaces the character under the cursor

<n>r<char> - replaces the next <n> characters from the cursor with <char>

R - overwrite mode / Replace characters

s - substitute, remove the character under cursor and enter insert mode

<n>s - remove the next <n> characters and enter insert mode


o - open ( leave in insert mode) a new line under current line with correct indenting

O - same as o, but open above

x - delete character
dd - delete line
u - undo

A - append to end of current line ( leaves in insert mode )
a - append after current cursor (leaves in insert mode )

##Navigaton

h - cursor left
j - cursor down
k - cursor up
l - cursor down

w - beginning of next word
e - end of next word
b - beginning of previous word,  if in the middle of a word, it goes back to the beginning of that word

gd - goto defention ( use ontop of methods  / classes etc )
zz - center current line in center of screen
