### University System - ASP.NET API (MVC) & ANGULAR 15.1.0

## Backend - ASP.NET API (MVC)

### Requirements - ✅
- OS: Windows32 x64  
- NET: 6.0  

---

### Run - ⚡
1. Open the project repository.  
2. Locate the file "Start Backend.exe":  
   - Note: This file is a shortcut to the compiled project executable located in `./Backend/bin/Release/net6.0/Backend.exe`.  
3. Run the file.

---

## Frontend - Angular 15.1.0

### Requirements - ✅
- OS: Windows32 x64  
- NODE: 18.12.1  
- NPM: 8.19.2  
- Angular CLI: 15.0.5  

---

### Run - ⚡

#### Manual
1. Open a command-line terminal:  
   - Examples: CMD, Windows Terminal, Windows PowerShell, etc.  
2. Globally install the *http-server* package via NPM:  
   - Command: `$ npm install --global http-server`  
3. Navigate to the project's root folder in the terminal.  
4. Start the server with the installed package (*http-server*):  
   - Command: `$ http-server ./Frontend/build/ --cors`  
5. After the server starts, in the terminal under *Available on:*, copy the last of the three listed hosting URLs:  
   - Note: The last one should be selected due to CORS configuration requirements.  
6. Open a browser:  
   - Examples: Chrome, Edge, Brave, Opera, etc.  
7. Paste the URL into the address bar and navigate to it.

#### Automated via .bat
1. Open the project repository.  
2. Locate the file "Start Frontend.bat":  
   - Note: This file automates the installation and initialization of the server, specifically the two commands used in the **Manual** process.  
3. After the server starts, in the terminal under *Available on:*, copy the last of the three listed hosting URLs:  
   - Note: The last one should be selected due to CORS configuration requirements.  
4. Open a browser:  
   - Examples: Chrome, Edge, Brave, Opera, etc.  
5. Paste the URL into the address bar and navigate to it.  

---
