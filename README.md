# VsVim + Resharper Guide with C# editing scenarios

Stack: Visual Studio 2017 - Resharper 2018.2 - VsVim 2.6 - AceJump - AutoHotKey - RelativeLineNumbers

This is an opinionated guide on how to use Resharper and VsVim together for C# programming ( While still applicable for F# and VB.NET, the examples and focus on C#)

Vims power comes from chaining combinations together, and while much of vim is well documented it is often hard to learn effective combos, and with Resharper we have a lot more combos at our disposal.  The purpose of this guide is to document really good VsVim / Resharper editing techniques by leveraging various combos.

If there are any editing scenarios in relation to C# coding not covered raise an issue, or, if you have a scenario you think would be good for the guide, raise a PR on the repository
https://github.com/keithn/vsvimguide.git

# Setup

This is largely down to personal preference, but by default, some things are slightly tricky to deal with and adaptions / compromises need to be made.  The following is an opinionated setup that is meant as a starting point for customization.

## Visual Studio

Visual Studio provides lots of mouseable targets on the screen.  For keyboard oriented programming these targets are really not needed and every time you have to reach for your mouse it feels like wasted time. Unfortunately a lot of the Visual Studio Modals are not very keyboard friendly, you can drive them through the keyboard, but it is often semi painful.  The following changes are recommend ( though not necessary )

- Enter Full Screen ( View -> Fullscreen or ```Shift-Alt-Enter``` )
- Turn off all toolbars.  You will access all the functionality you need through the keyboard
- Unpin all the side / bottom tool windows.  
- Turn off sidebar tabs (Window -> Show Sidebar Tabs, or ```ALT-W b```)
- Turn off scrollbars (Tools -> Options -> Text Editor -> All Languages -> Scrollbars)
- Turn on line numbers are displayed (Tools -> Options -> Text Editor -> General -> Line Numbers )

Turning off scrollbars tends to be the most surprising setting for people used to using a mouse.  You'll find that you don't actually use the scrollbars too often and the times you do want to scroll through your code with your mouse you find the mousewheel tends to be good enough.

## Resharper / VsVim Handling of Ctrl

In the VsVim Settings you can set whether VsVim or VisualStudio should handle the various Ctrl key combinations, there is fine grained control over the various Ctrl combinations, but in general, prefer using VsVim if VsVim has functionality that uses Ctrl.   Key Combinations that involve Shift and Alt are fine and don't clash with VsVim so can be left as desired though you can also optionally map combos to Vim friendly combos also.  You can leave the following ```Ctrl``` keys left bound to visual studio

```Ctrl-t```  - Not supported by VsVim, so nicer left bound to resharpers search functions

## Unit Testing 

Resharpers unit test runner is quite powerful but it can be difficult to setup through the keyboard so it is generally better to use the mouse to set it up.  However once you set the settings correctly, the general process of unit testing is fully keyboard driven.  The following are some general tips on how to make the best use of it

- Change Settings to Auto highlight test session on run ( Resharper -> Options -> Unit Testing -> Activate Unit Test Session when run starts )
- Dock it as window rather than a toolbar window, size it so it's easy to read the failure messages
- Set Autoscroll on
- Set Autostart on so it will Run all tests on Build

The activating of the test session when run start doesn't activate when auto building, which is what you want as otherwise it would get annoying losing your focus. It only activates when you activate the testing through a manual action.  To get back to your code press ```<Escape>```  

If a test fails on auto build


### Key Bindings

Running unit tests is handled from the Vim bindings, but there are number of options you will want to set in the Unit Test Session that ReSharper provides.  The following are recommend bindings for the Unit Session Window

```Alt-1```  - ReSharper.UnitTestSessionAutoScrollOutput

```Alt-2```  - ReSharper.UnitTestSessionTrackRunningTest

```Alt-3```  - ReSharper.ContinuousTestingRunNewAndOutdatedMode

```Alt-4```  - ReSharper.ContinuousTestingRunNewAndOutdatedMode

```Alt-5```  - ReSharper.ContinuousTestingCoverNewAndOutdatedMode

Toggling Any of the Alt 3 4 5 will turn of Continuous Test Mode


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
map <Space>m :vsc ReSharper.ReSharper_ExtractMethod<CR>
map <Space>o :vsc ReSharper.ReSharper_Move<CR>
map <Space>t :vsc ReSharper.ReSharper_GotoType<CR>
map <Space>tr :vsc ReSharper.ReSharper_UnitTestRunFromContext<CR>
map <Space>td :vsc ReSharper.ReSharper_UnitTestDebugContext<CR>
map <Space>ta :vsc ReSharper.ReSharper_UnitTestRunSolution<CR>
map <Space>tl :vsc ReSharper.ReSharper_UnitTestSessionRepeatPreviousRun<CR>
map <Space>tt :vsc ReSharper.ReSharper_ShowUnitTestSessions<CR>
map <Space>b :vsc Build.BuildSolution<CR>
map <Space><Space> :vsc Tools.InvokeAceJumpCommand<CR>
map <Space>; A;<Esc>
map ] :vsc ReSharper.ReSharper_GotoNextMethod<CR>
map [ :vsc ReSharper.ReSharper_GotoPrevMethod<CR>
map zl :so ~/.vsvimrc<CR>

```

To access non Vim things ```<Space>``` is super useful, normally in Vim it would advance you one letter.  In practice this is of limited use
 
Most of these are bindings to resharper commands that VsVim hides, these are the commands that are normally bound to ```<Ctrl>-<SomeKeyCombo>```  to ```<Space>-<Letter>```.  Customize this to suit

It also maps AceJump to ```<Space><Space>```.  AceJump allows you to quickly jump to different points in the code.  See [AceJump in Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=jsturtevant.AceJump) for a demo of how it works.  It is a limited implementation of a popular plugin in Vim called 'EasyMotion'.  There is also a plugin for Visual Studio called easymotion which is written by the same author as VsVim, but ironically isn't compatible with VsVim.  

The ```[ ]``` keys are bound to next and previous method, the default Vim behavior is not generally that useful when coding C# / F#

```zl``` is just a quick way to reload your vim settings. WARNING - it doesn't reset your keybindings, so if you remove a mapping, and reload, it won't get rid of the mapping.  But it is useful for loading new bindings / settings

## Auto Hot Key

There are a number of bindings which Visual Studio and vsvim can't change when it comes to resharper and pop up dialogs.   In this repository there is a auto hot key script (vsvim.ahk) which binds the following keys

```Caps Lock``` - ```Esc```  This is one of the most useful bindings as the ```Esc``` key is needed a lot and for many people they hardly ever use ```Caps Lock``` 
```ALT-K``` -  Up Arrow, this is for use in popup dialogs like any of R# goto dialogs
```ALT-J``` -  Down Arrow

Set this script to run on startup.

The ```Alt-K``` and ```Alt-J``` Combos are useful in many cases where normally you'd have to use the arrow keys in windows or dropdown lists.  Reaching for the arrow keys is generally always an annoying action for a Vimmer.  If you haven't used VsVim and Resharper together yet then it won't be obvious that this happens a LOT with Resharper as you do various refactorings little dropdowns come up with various options, and it really slows you down if you have to reach for the arrow keys

# VsVim Fundamentals

The main reason for this guide is essentially how to use Vim effectively with visual studio and resharper.  The key motivation to VsVim is to be able to leverage Vims powerful editing capabilities within Visual Studio, so we need to spend a lot of effort to get really effective with standard vim commands ( and specifically VsVim ).  But often we step outside of Vim and make use of resharper / auto complete / refactorings / code generation / templates / Visual Studio hot keys to better leverage all the toys at our disposal

## How to switch to VsVim as a complete Noob

This isn't trying to be a beginners guide but just some general advice for beginners about how to make the switch without too much friction.  Vim takes a while to get good at and much of the advice advocates enduring the pain until you get good enough, but you don't have to.   You can go through a progression.

- It's ok to stay in insert mode, use arrow keys, and your mouse, everything will be semi normal
- Start coming out of insert mode to practice Vim things,  hjkl to move around, w to move between words,  dd to delete lines, c commands to change text like ciw ci" cw, and the corresponding delete commands  diw dw   
- Keep learning commands like the ones in this guide till you are using them by default
- Start challenging yourself to stay out of insert mode
- At this point you should start feeling Vim is a more productive way to edit and you'll naturally keep expanding your skills, keep looking at tips.  It is not unusual for tips to open your eyes to completely different ways of how you can do things.

## Changing Text


```cw```  - changes the word from the cursor to the end of the word

```ciw``` - changes the entire worth that the cursor is on

```cf<char>``` - changes text until you find the character <char>, includes the find char

```ct<char>``` - changes text until you find the character <char>, but don't include the char

```c<n>f<char>``` -  same as previous cf but find the nth occurrence of the char

```c<n>t<char>``` -  same as previous ct but find the nth occurrence of the char

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

## Navigation

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

```gd``` - goto definition ( use on top of methods  / classes etc )

```zz``` - center current line in center of screen

```*``` - search for word under cursor

```m<char>``` - mark current location and store it in ```<char>```  if the letter is a Capital letter, then it works across files

``` `<char>``` - goto mark set in ```<char>```  if the letter is a capital letter it will jump to the file with the mark

## Searching

Use it to navigate to places faster

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

## Positioning

For many of the scenarios in this guide, positioning your cursor in the right place is the very first task, these scenarios cover a number of ways to get your cursor to the right place.  

*TO BE DONE*

## Refactorings

### Introduce Variable

Resharper introduces a variable for a selection or whole line.  

Given the following code  
```csharp
public int Add(int a, int b)
{
  return a + b;
}
```
if we want to introduce a variable called ```sum``` then we go to the line with the return statement and position the cursor anywhere in ```a + b``` and type

```<Space>v```

This will introduce a variable

```var add = a + b;``` we now press ```<Tab> to leave the type as ```var``` and then we type ```sum<Tab>``` to change the variable name and then finally <Tab> to complete the refactoring at which point the code will now look like

```csharp	
public int Add(int a, int b)
{
    var sum = a + b;
    return sum;
}
```

More problematic is when we want to introduce a variable for a partial part of a statement, given the following code

```csharp
public int Average(int a, int b)
{
    return (a + b) / 2;
}
```

We again want to introduce a variable for the sum part, however this time we will need to select the ```(a + b)```

So first we position ourselves anywhere between or on the brackets ```(a + b)``` then we type

```vab``` which creates a visual selection inclusive of the brackets, now we can introduce a variable with 

```<Space>v```, and then we ```<Tab>``` through the introduce variable refactoring as in the previous example

The code will now look like

```csharp
public int Average(int a, int b)
{
    var sum = (a + b);
    return sum / 2;
}
```





# Resources 

## Websites

http://vim.wikia.com/wiki/Vim_Tips_Wiki  - so much gold here, but hard to find relevant nuggets

https://vimhelp.appspot.com/index.txt - definitive list of all Vim commands

