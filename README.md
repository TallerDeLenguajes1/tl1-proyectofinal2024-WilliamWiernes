# :clipboard: Harry Potter y el Club de Duelos

## :star2: Introducción
### :question: ¿De qué trata?
- Es un juego desarrollado para el Proyecto Final de Taller de Lenguajes I.  
- Se basa en el universo de Harry Potter, donde como jugador deberás enfrentarte en un no muy legal Club de Duelos, llevado a cabo en Hogsmade, un pueblo cercano al Colegio de Magía y Hechizería Hogwarts, a otros 5 estudiantes para poder ganar.  

## :nut_and_bolt: Instalación y Configuración
### :computer: Requisitos del Sistema
- Tener instalado _.NET 8.0_ o instalarlo desde su [página oficial](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- Sistema operativo _Windows 10_ (preferentemente), _MacOS_ o _Linux_.
- 200MB de espacio en disco.
- 4gb de ram.

### :inbox_tray: Instalación
- Descargar el [.zip](https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-WilliamWiernes/archive/refs/heads/main.zip) y extraerlo
- O también se puede clonar el repositorio
``` bash
    git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-WilliamWiernes.git
```
git 
## :book: Uso
### :rocket: Guía de Inicio Rápido
1. _Windows_ + _R_, escribir *cmd* y dar _Enter_
2. Cambiar la *ruta* en base a dónde se descargó el archivo y pegar en el *cmd*
``` bash
    cd C:\Users\USUARIO\Downloads\tl1-proyectofinal2024-WilliamWiernes-main
```
3. Correr el código usando el siguiente comando en el *cmd*
``` bash
    dotnet run
```

### :memo: Manual del Usuario
Si no hay datos preexistentes desde un json, se le pedirá al jugador ingresar su nombre y sexo, y se genereran el resto de personajes desde la API.
Es importante tener en cuenta que para que el sistema de colisiones funcione correctamente, el personaje principal debe estar a la *misma altura* por debajo, izquierda o derecha del personaje al cual desee enfrentarse, de otra manera los personajes se sobrepondran causando un desorden visual, el cual no afecta en absoluto a funcionamiento del programa.

## :link: Dependencias
### :books: Bibliotecas y Herramientas
- [API a Objeto C#](https://json2csharp.com/)
- [ASCII Art](https://emojicombos.com/harry-potter-ascii-art)
- [Generar ASCII Art por imagenes](https://www.ascii-art-generator.org/)
- [Texto ASCII con marco y fuentes seleccionables](https://www.asciiart.eu/text-to-ascii-art)
- [Descargar audio de Youtube](https://flvto.pro/es16/)
- [Convertir MP3 a Wav](https://convertio.co/es/audio-converter/)
### :earth_americas: API Externas
- [Harry Potter API](https://hp-api.onrender.com/api/characters/students)
- [Documentación Oficial](https://learn.microsoft.com/en-us/dotnet/csharp/)

## :wrench: Solución de Problemas
Un problema común se relaciona con el tamaño de la consola, por defecto vienen valores en donde se puede jugar como fue pensado el juego, pero monitores menores a 24 pulgadas pueden presentar problemas con la altura de la consola. La solución es sencilla: ingresar al _Program.cs_ y cambiar el valor de la variable entera _Altura_ por un valor que haga que la consola se puede apreciar correctamente en la pantalla.

## :pray: Agradecimientos
- Canal de Youtube [Jhampo](https://www.youtube.com/@jhampo)
1. Sus videos _Crea tu Primer Juego DESDE 0 en C# -_ [Parte1](https://www.youtube.com/watch?v=SqNOKrVey_w&t=311s) y [Parte 2](https://www.youtube.com/watch?v=ibRU8I5pLG0&t=930s) ayudaron a generar la movilidad del personaje y el sistema de colisiones.
- [García Franco Tomás](https://github.com/FrancoTms) por personalizar la canción del juego.  