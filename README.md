# VsVim + Resharper Guide with C# editing scenarios

Stack: Visual Studio 2017 - Resharper 2018.2 - VsVim 2.6 - AceJump - AutoHotKey

This is an opionated guide on how to use Resharper and VsVim together for C# programming ( While still applicable for F# and VB.NET, the examples and focus on C#)

Vims power comes from chaining combinations together, and while much of vim is well documented it is often hard to learn effective combos, and with Resharper we have a lot more combos at our disposal.  The purpose of this guide is to document really good VsVim / Resharper editing techniques by leveraging various combos.

If there are any editing scenarios in relation to C# coding not covered raise an issue, or, if you have a scenario you think would be good for the guide, raise a PR on the repository
https://github.com/keithn/vsvimguide.git

# Setup

This is largely down to personal preference, but by default, some things are slightly tricky to deal with and adaptions / compromises need to be made.  The following is an opinionated setup that is meant as a starting point for customization.


## Resharper / VsVim Handling of Ctrl

In the VsVim Settings you can set whether VsVim or VisualStudio should handle the various Ctrl key combinations, there is fine grained control over the various Ctrl combintaions, but in general, perfer using VsVim if VsVim has functionality that uses Ctrl.   Key Combinations that involve Shift and Alt are fine and don't clash with VsVim so can be left as desired though you can also optionally map combos to Vim friendly combos also.  You can leave the following ```Ctrl``` keys left bound to visual studio

```Ctrl-t```  - Not supported by VsVim, so nicer left bound to resharpers search functions

### Unit Testing Key Combos

Usually unit testing is accessed through ```<Ctrl>-U<Letter>```  this interferes with VsVim "Half Page Up".  So perfer to bind the Unit Testing shortcuts to ```Alt-<Number>```.  It is also worthwhile to set the scope for this to be global to visual studio and remove all other keybindings in other scopes where it uses the Alt Number combos.  This of course depends on your preferences and what other tools you make use of inside Visual Studio 

Reccommened Bindings :-

```Alt-1```  - ReSharper.ReSharper_UnitTestRunFromContext

```Alt-2```  - ReSharper.ReSharper_UnitTestDebugContext

```Alt-3```  - ReSharper.ReSharper_UnitTestRunSolution

```Alt-4```  - ReSharper.ReSharper_UnitTestSessionRepeatPreviousRun

```Alt-5```  - ReSharper.ReSharper_UnitTestSessionNewSession

```Alt-6```  - ReSharper.ReSharper_UnitTestRunCurrentSession

```Alt-7```  - ReSharper.ReSharper_UnitTestSessionAppendTests



## .vsvimrc

This is where you can map keys like the traditional vim editor (it lives in your windows user home directory).  VsVim also allows you to bind things to visual studio commands, and by extension, resharper.  The following are a number of useful bindings 

```
set ignorecase
set clipboard=unnamed

map gd :vsc ReSharper.ReSharper_GotoDeclaration<CR>
map <Space>r :vsc ReSharper.ReSharper_Rename<CR>
map <Space>f :vsc ReSharper.ReSharper_GotoFileMember<CR>
map <Space>e :vsc ReSharper.ReSharper_GotoNextErrorInSolution<CR>
map <Space>E :vsc ReSharper.ReSharper_GotoPrevErrorInSolution<CR>
map <Space>s :vsc ReSharper.ReSharper_SurroundWith<CR>
map <Space>l :vsc ReSharper.ReSharper_LiveTemplatesInsert
map <Space>u :vsc ReSharper.ReSharper_GotoUsage<CR>
map <Space>d :vsc ReSharper.ReSharper_DuplicateText<CR>
map <Space>, :vsc ReSharper.ReSharper_GotoText<CR>
map <Space>v :vsc ReSharper.Resharper_IntroVariable<CR>
map <Space>o :vsc ReSharper.ReSharper_Move<CR>
map <Space>t :vsc ReSharper.ReSharper_GotoType<CR>
map <Space><Space> :vsc Tools.InvokeAceJumpCommand<CR>
map <Space>; A;<Esc>
map ] :vsc ReSharper.ReSharper_GotoNextMethod<CR>
map [ :vsc ReSharper.ReSharper_GotoPrevMethod<CR>
map zl :so ~/.vsvimrc<CR>
```

To access non Vim things ```<Space>``` is super useful, normally in Vim it would advance you one letter.  In practice this is of limited use
 
Most of thse are bindings to resharper commands that VsVim hides, these are the commands that are normally bound to ```<Ctrl>-<SomeKeyCombo>```  to ```<Space>-<Letter>```.  Customize this to suit

It also maps AceJump to ```<Space><Space>```.  AceJump allows you to quickly jump to differnt points in the code.  See [AceJump in Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=jsturtevant.AceJump) for a demo of how it works.  It is a limited implemenation of a popular plugin in Vim called 'EasyMotion'.  There is also a plugin for Visual Studio called easymotion which is written by the same author as VsVim, but ironically isn't compatible with VsVim.  

The ```[ ]``` keys are bound to next and previous method, the default Vim behaviour is not generally that useful when coding C# / F#

```zl``` is just a quick way to reload your vim settings. WARNING - it doesn't reset your keybindings, so if you remove a mapping, and reload, it won't get rid of the mapping.  But it is useful for loading new bindings / settings

## Auto Hot Key

There are a number of bindings which Visual Studio and vsvim can't change when it comes to resharper and pop up dialogs.   In this repository there is a auto hot key script (vsvim.ahk) which binds the following keys

```Caps Lock``` - ```Esc```  This is one of the most useful bindings as the ```Esc``` key is needed a lot and for many people they hardly ever use ```Caps Lock``` 
```ALT-K``` -  Up Arrow, this is for use in popup dialogs like any of R# goto dialogs
```ALT-J``` -  Down Arrow

Set this script to run on startup.

The ```Alt-K``` and ```Alt-J``` Combos are useful in many cases where normally you'd have to use the arrow keys in windows or dropdown lists.  Reaching for the arrow keys is generally always an annoying action for a Vimmer.

# VsVim Fundamentals

The main reason for this guide is essentially how to use Vim effectively with visual studio and resharper.  The key motivation to VsVim is to be able to leverage Vims powerful editing capabilites within Visual Studio, so we need to spend a lot of effort to get really effective with standard vim commands ( and sepecifically VsVim ).  But often we step outside of Vim and make use of resharper / auto complete / refactorings / code generation / templates / Visual Studio hot keys to better leverage all the toys at our disposal

## How to switch to VsVim as a complete Noob

This isn't trying to be a beginners guide but just some general advice for beginners about how to make the switch without too much friction.  Vim takes a while to get good at and much of the advice advocates enduring the pain until you get good enough, but you don't have to.   You can go through a progression.

- It's ok to stay in insert mode, use arrow keys, and your mouse, everything will be semi normal
- Start coming out of insert mode to practice Vim things,  hjkl to move around, w to move between words,  dd to delete lines, c commands to change text like ciw ci" cw, and the corresponding delete commands  diw dw   
- Keep learning commands like the ones in this guide till you are using them by default
- Start challenging yourself to stay out of insert mode
- At this point you should start feeling Vim is a more productive way to edit and you'll naturally keep expanding your skills, keep looking at tips.  It is not unusual for tips to open your eyes to completely different ways of how you can do things.

## Changing Text


```cw```  - changes the word from the cusor to the end of the word

```ciw``` - changes the entire worth that the cursor is on

```cf<char>``` - changes text until you find the chararcter <char>, includes the find char

```ct<char>``` - changes text until you find the charracter <char>, but don't include the char

```c<n>f<char>``` -  same as previous cf but find the nth occurance of the char

```c<n>t<char>``` -  same as previous ct but find the nth occurance of the char

```ci(``` - change text inside current brackets ( ) 

```ci{``` - change text inside current curly braces { }

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

```H``` - put cursor at top of screen

```M``` - put cursor in middle of screen

```L``` - put cursor at bottom of screen

```w``` - beginning of next word

```e``` - end of next word

```b``` - beginning of previous word,  if in the middle of a word, it goes back to the beginning of that word

```gd``` - goto defention ( use ontop of methods  / classes etc )

```zz``` - center current line in center of screen

```*``` - search for word under cursor

```m<char>``` - mark current location and store it in ```<char>```  if the letter is a Capital letter, then it works across files

``` `<char>``` - goto mark set in ```<char>```  if the letter is a capital letter it will jump to the file with the mark

## Searching

Use it to nagigate to places faster

```/```  search forward,  by itself repeats the last search but forwards

```?```  search back, by itself repeats the last search but backwards

```n```  find next, will go to the next forward or the next back  ( depends on whether you used ```/``` or ```?```)

```N```  find previous, will go to the previous forward or the previous back


From the .vsvimrc bindings

```[``` - Previous Method (triggers R#)

```]``` - Next Method (triggers R#)

# Resharper Fundamentals

Assuming the Visual Studio key bindings are used

```Ctrl+t``` - Navigate to File

```Alt+Ins``` - Generate Menu, allows you to generate code depending on current context

```Ctrl+Alt+Enter``` - Format the current file ( never fight resharpers formatting, configure it if you don't like it)

```Ctrl+r-o``` - Move class to another file

```Ctrl+Alt+/``` - Comment Out line of code / Selection

```Alt+Enter``` - Context aware Actions / Quick fixes / transformations


# Visual Studio Fundamentals

```Ctrl+Q``` - Quick Launch, allows you to search and run any command visual studio knows about, tells you if it has a key binding, and its menu location.  

```Alt+F-d-n``` - Add new project to solution

```Alt+T-n-n``` - Manage Nuget Packages for Solution

```Alt-Alt``` - Make auto complete dialogs disappear, super useful as by default esc is what's commonly used which will take you out of insert mode.

# Scenarios

TBD

# Resources 

## Websites

http://vim.wikia.com/wiki/Vim_Tips_Wiki  - so much gold here, but hard to find relevant nuggets

https://vimhelp.appspot.com/index.txt - definitive list of all Vim commands

