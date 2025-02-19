Instrucciones de instalación y uso de la API.

1. Primero creamos un proyecto de bibliotecas de clases .NET llamado APIREST

2. Luego instalamos paquetes como EntityFramework, EntityFrameworkCore, EntityFrameworkSqlServer,
   EntityFrameworkCore.Tools y EntityFrameworkCore.Design.

3. Luego creamos la cadena de conexion de a la base de datos, en donde buscamos nuestros servidor,
   tabla que utilizaremos y el usuario del Sql Server.

4. Despues desplegamos la consola y ponemos la cadena de conexion de la base de datos con nuestro
   respectivo id de usuario y la contraseña, en ese momento esperamos y veremos que tendremos el
   contexto y los modelos de la base de datos

5. Luego creamos una carpeta llamada REPOSITORY, dentro de esa carpeta creamos un archivo llamado
   PRODUCTO DAO que es un archivo donde estaran todas las funciones que ocuparemos para el CRUD
   (Leer, eliminar, actualizat e insertar)

6. Luego creamos un segundo proyecto que sera ProductosAPI con Asp.Net Core Web API

7. Dentro del proyecto ProductosAPI creamos un controlador llamado ProductoController que es donde
   crearemos los HTTP como PUT, DELETE, GET y PUSH.

8. Luego agregamos referncias del proyecto APIREST a nuestro proyecto ProductosAPI

9. Realizamos todas las funciones necesarias tanto las de CRUD como los end-point de los HTTP.

10. Luego de tener toda listo y bien estructurado podemos probar la api ejeuctando desde visual
    studio realizando pruebas con Postman o swagger.

11. Para leer todos los productos solo debemos de ejecutar el end-point de LeerProductos en la
    cual la URL es https://localhost:7198/api/LeerProductos

12. Para obtener un producto por id en el end-point debemos de colocar el id en la URL o en
    el input de swagger, en el caso de postman la URL seria https://localhost:7198/api/ObtenerPorId?id=10

13. Para eliminar un producto realizamos algo similar al de obtener por id solo que en esta ocuacion el
    producto sera eliminado, la URL para postman seria https://localhost:7198/api/EliminarProducto?id=23

14. Para insertar un producto es distinto ya que debemos de rellenar un json que nos proporciona el swagger
    o si lo hacemos en postman debemos de crear el json de la siguiente manera:
     { "idProducto": 0, "nombre": "string", "precio": 0, "stock": 0 }
    en donde cada apartado (menos en el idproducto ya que es incremental) debemos de rellenarlo y ejecutar
    la URL para insertar productos seria https://localhost:7198/api/InsertarProducto.

15. Por ultimo para editar un producto es similar a insertar, que debemos de rellenar el json o crearlo en
    donde debemos de colocar el ID del producto a modificar y cambiar ya sea el nombre, precio o stock.
    La URL para editar los productos seria https://localhost:7198/api/EditarProductos.
