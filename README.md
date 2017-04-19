# VsVim + Resharper Guide with C# editing scenarios

Stack: Visual Studio 2017 - Resharper 2017 - VsVim 2.3

Work in progress!  The guide highlights useful editing commands while programming using VsVim.  

Vims power comes from chaining combinations together, and while much of vim is well documented it is often hard to learn effective combo!

This guide ( currently ) assumes VsVim doesn't bind to any of the modifier keys ( like ctrl ) which leaves Resharpers bindings as default

If there are any editing scenarios in relation to C# coding not covered raise an issue, or, if you have a scenario you think would be good for the guide, raise a PR


# Setup

This is largely down to personal preference, but by default, some things make things slightly tricky to deal with

## Escape Key

The escape key is hugely important to Vim, however, the key itself is a bit far away on many keyboards.  So one popular option is to bind your capslock key to be escape ( there are other key combos you can bind escape to, but I think this is a good option if you never use your caps lock )

To do this install AutoHotKey, create a file on your desktop called  "CapsToEscape.cpk"
and put the following line in the file```Capslock::Esc```
then you can run this manually, or set it to run on startup, and magically your caps lock key will now be the esc key.  One thing to note, ensure caps lock is OFF before running the script otherwise you'll be stuck with caps on.


## .vsvimrc

This is where you can map keys to vim commands.  VsVim allows you to bind things to visual studio, and by extension, resharper.  The following are a number of useful bindings 

```
nnoremap gd :vsc ReSharper.ReSharper_GotoDeclaration<CR>
set clipboard=unnamed
map ;; A;<Esc>
map ] :vsc ReSharper.ReSharper_GotoNextMethod<CR>
map [ :vsc ReSharper.ReSharper_GotoPrevMethod<CR>
```

this maps gd ( goto definition ) to resharpers version

it sets the windows clipboard to bind to vims default buffer it cuts and pastes to ( which is really useful if you use a clipboard manager like ditto )

It maps ;; to append a semi colon to the end of the line without going into insert mode.  This is useful as much resharper / vim magic generates code for you while not in insert mode but leaves the code without the final semicolon.

it binds [ and ] to resharpers goto previous and next method.   By default, in vim, this is previous and next section which has little use within visual studio.  


# VsVim Fundamentals

The main reason for this guide is essentially how to use VsVim effectively with visual studio and resharper.  It's a semi niche corner of the coding world. So one of the most important things is to be reasonablly effective with vim editing ( and sepecifically VsVim ).  But often we step outside of Vim and make use of resharper / auto complete / refactorings / code generation / templates / Visual Studio hot keys to better leverage all the toys at our disposal

## How to switch to VsVim as a complete Noob

This isn't trying to be a beginners guide but just some general advice for beginners about how to make the switch without too much friction.  Vim takes a while to get good at and much of the advice advocates enduring the pain until you get good enough, but you don't have to.   You can go through a progression.

- It's ok to stay in insert mode, use arrow keys, and your mouse, everything will be semi normal
- Start coming out of insert mode to practice Vim things,  hjkl to move around, w to move between words,  dd to delete lines, c commands to change text like ciw ci" cw, and the corresponding delete commands  diw dw   
- Keep learning commands like the one in this guide till you are using them by default
- Start challenging yourself to stay out of insert mode
- At this point you should start feeling Vim is a more productive way to edit and you'll naturally keep expanding your skills, keep looking at tips, often many of the combos won't occur to you even though you know what the commands do.  Or you may find there is even a better combo than the current combo you use.


## Changing Text


```cw```  - changes the word from the cusor to the end of the word

```ciw``` - changes the entire worth that the cursor is on

```cf<char>``` - changes text until you find the chararcter <char>, includes the find char

```ct<char>``` - changes text until you find the charracter <char>, but don't include the char

```c<n>f<char>``` -  same as previous cf but find the nth occurance of the char

```c<n>t<char>``` -  same as previous ct but find the nth occurance of the char

```ci(``` - change text inside current brackets ( ) 

```ci{`` - change text inside current curly braces { }

```ci'``` - change text inside current ' quotes

```ci"``` - change text inside current " quotes

```cit``` - change text inside current html/xml tag  

```r<char>``` - replaces the character under the cursor

```<n>r<char>``` - replaces the next ```<n>``` characters from the cursor with ```<char>```

```R``` - overwrite mode / Replace characters

```s``` - substitute, remove the character under cursor and enter insert mode

```<n>s``` - remove the next ```<n>``` characters and enter insert mode


```o``` - open ( leave in insert mode) a new line under current line with correct indenting

```O``` - same as o, but open above

```x``` - delete character

```dd``` - delete line

```u``` - undo

```A``` - append to end of current line ( leaves in insert mode )

```a``` - append after current cursor (leaves in insert mode )

## Navigaton

```h``` - cursor left

```j``` - cursor down

```k``` - cursor up

```l``` - cursor down

```w``` - beginning of next word

```e``` - end of next word

```b``` - beginning of previous word,  if in the middle of a word, it goes back to the beginning of that word

```gd``` - goto defention ( use ontop of methods  / classes etc )

```zz``` - center current line in center of screen

```*``` - search for word under cursor

```m<char>``` - mark current location and store it in ```<char>```

``` `<char>``` - goto mark set in ```<char>```

# Resharper Fundamentals

Assuming the Visual Studio key bindings are used

```ctrl-t``` - Navigrate to File

```Alt-Ins``` - Generate Menu, allows you to generate code depending on current context

```Ctrl-Alt-Enter``` - Format the current file ( never fight resharpers formatting, configure it if you don't like it)

```Ctrl-r-o``` - Move class to another file

# Visual Studio Fundamentals

```Ctrl-Q``` - Quick Launch, allows you to search and run any command visual studio knows about, tells you if it has a key binding, and its menu location.  


<kbd>Alt</kbd>+<kbd>F</kbd><kbd>d</kbd><kbd>n</kbd>  - Add new project to solution

# Scenarios



# Resources 

## Websites
http://vim.wikia.com/wiki/Vim_Tips_Wiki  - so much gold here, but hard to find relevant nuggets

## Software

http://carnackeys.com/ - Displays key combos on your screen

https://obsproject.com/ - Free open source Screen casting software



