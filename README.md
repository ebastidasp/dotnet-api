# DOTNet Server

Este servidor hecho en C# con el framework de .NET tiene los siguientes requisitos para que se pueda correr localmente:

## Prerequisitos:

- .NET SDK.

- Visual Studio.

- Un programa como Postman para probar los endpoint.

## Pasos para correr el proyecto.

### 1. Clonar el repositorio

---

git clone https://github.com/ebastidasp/dotnet-api.git

---

### 2. Restaurar las dependencias

---

dotnet restore

---

### 3. Aplicar migraciones y actualizar la base de datos

Primero se instala el EF CLI con el siguiente comando:

---

dotnet tool install --global dotnet-ef

---

Y después se ejecuta el comando para aplicar la migración:

---

dotnet ef database update

---

### 4. Correr la api

---

dotnet run

---

### 5. Probar los endpoints

Después de todos estos pasos, podrás probar los endpoint en la url:

https://localhost:5021

Todas las rutas de este servidor usan el método HTTP GET, y son:

/api/fact para obtener un dato aleatorio sobre gatos.

/api/gif?query=''&fullFact=''&length=0 para generar un gif en base a una query y guardar el dato aleatorio sobre gatos en base de datos postgreSQL.

/api/history?page=1&limit=15 para obtener los datos paginados de todos los datos y gifs que se han obtenido y que están guardados en la base de datos.

Nota: En este caso, los accesos a la base de datos están expuestos, ya en un entorno de producción sería mejor dejar esas credenciales del archivo appsettings.json ocultas.
