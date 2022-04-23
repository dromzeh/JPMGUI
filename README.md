# JPMGUI (Java Path Manager GUI)
- Basic GUI for easily modifying Java Path / Environment Variables made with C# for Windows Only.
- You can also compile this for yourself - I used VS2022.
- The program requests for UAC as it is modifying Environment Variables.
- *Note: This is just a program I quickly made I constantly found switching between Java Paths was tiring and this is the most convenient option for me, code is nothing too complex. I might add more to this in the future if needed.*

# Requirements
- [.NET 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472).

# Usage
- Program is simple to use, select the folder where you have all your java versions saved **(NOT the actual jdk/jde folder)** & in the dropdown select the Java Version you want to use, then 'Set Path'.

<img src = "https://cdn.discordapp.com/attachments/833632547207643139/967394351388958720/unknown.png"></img>

# Features
- Allows for you to change your current selected Java path to any other one of your choice.
- Program automatically removes any existing entries of Java directories in the `Path` Variable to prevent flood.
- Program remembers your selected 'Java' Folder and automatically sets it on startup. (You can remove the settings in `%appdata%/local`).
