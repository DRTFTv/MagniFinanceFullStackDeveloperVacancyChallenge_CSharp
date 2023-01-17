@ECHO Start frontend - Angular
call npm install --global http-server
call http-server ./Frontend/build/ --cors
