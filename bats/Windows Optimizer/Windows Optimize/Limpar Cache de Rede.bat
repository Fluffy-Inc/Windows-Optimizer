@echo off

echo Limpando e otimizando DNS...
ipconfig /flushdns
ipconfig /release
ipconfig /renew
netsh int ip reset
netsh winsock reset
echo Rede otimizada!
pause
