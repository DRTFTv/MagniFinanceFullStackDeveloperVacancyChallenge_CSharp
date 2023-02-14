# Sistema Universidade - ASP.NET API (MVC) & ANGULAR 15.1.0

## Backend - ASP.NET API (MVC)

### Requisitos - ✅
* OS: Windows32 x64
* NET: 6.0
---

### Executar - ⚡
* Abra o repositório do projecto;
* Localize o arquivo "Start Backend.exe":
  * Observação: Este arquivo é um atalho do executável do projecto já compilado que se encontra na pasta ./Backend/bin/Release/net6.0/Backend.exe;
* Execute-o.
---

## Frontend - Angular 15.1.0

### Requisitos - ✅
* OS: Windows32 x64
* NODE: 18.12.1
* NPM: 8.19.2
* Angular CLI: 15.0.5
---

### Executar - ⚡
#### Manual
* Abra um terminal de código:
  * Exemplo: CMD, Windows terminal, Windows PowerShell, etc;
* Instale globalmente via o manejador de pacotes NPM o pacote *http-server*:
  * Comando: $ npm install --global http-server ;
* Ainda no terminal, navegue até a pasta raiz do projeto;
* Inicie o servidor com o pacote instalado (*http-server*):
  * Comando: $ http-server ./Frontend/build/ --cors
* Após o servidor ser iniciado, no terminal, em *Available on:* copie a última das três URLs de hospedagem listadas;
 * Observação: A última deve ser seleccionada por questões de configuração de CORS, que forçam uma identificação:
* Abra um navegador:
  * Exemplo: Chrome, Edge, Brave, Opera, etc;
* Cole a URL e pesquise.

#### Automatizado via .bat
* Abra o repositório do projecto;
* Localize o arquivo "Start Frontend.bat";
  * Observação: Este arquivo contém a parte de instalação e inicialização do servidor, especificamente os dois comando utilizados na etapa **Manual**.
* Após o servidor ser iniciado, no terminal, em *Available on:* copie a última das três URLs de hospedagem listadas:
 * Observação: A última deve ser seleccionada por questões de configuração de CORS, que forçam uma identificação;
* Abra um navegador:
  * Exemplo: Chrome, Edge, Brave, Opera, etc;
* Cole a URL e pesquise.
---

