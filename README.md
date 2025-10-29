TP_GestionGYM_Grupo4
Este sistema de gestión de gimnasio permite administrar de forma integral las operaciones relacionadas con clientes, clases, suscripciones y pagos. Ofrece funcionalidades tanto para administradores como para clientes, incluyendo el registro, inicio de sesión, inscripción a clases, adquisición de suscripciones y generación de comprobantes de facturación.

El administrador puede gestionar clientes y clases mediante operaciones de alta, baja y modificación, además de acceder a reportes clave sobre actividad e ingresos. El sistema también permite visualizar precios, realizar pagos por suscripciones y emitir comprobantes automáticos, facilitando la administración contable del gimnasio.

entidades principales:

cliente
administrador
clases
suscripciones
pagos
Funcionalidades principales:

El sistema debe permitir al administrador ABM de clientes.
El sistema debe permitir al administrador ABM de clases.
El sistema debe permitir al administrador ABM de suscripciones.
El sistema debe permitir el inicio de sesión en el sistema con correo y contraseña
El sistema debe permitir el registro de un cliente al sistema completando un formulario con datos básicos
El sistema debe permitir la inscripción a clases.
El sistema debe permitir al administrador cargar una suscripcion a un cliente registrado
El sistema debe ofrecer una opcion de registrar un pago por suscripcion cuando se realiza.
reportes:

El sistema debe permitir al administrador poder visualizar una lista de clientes activos junto a las suscripciones que los mismos están pagando, junto al monto.
El sistema debe ofrecer un reporte de los ingresos por suscripciones pagas
El sistema debe ofrecer un reporte que muestre por pantalla todos los clientes y un contador que sume los clientes activos en el sistema.
El sistema poseera tres capas bien diferenciadas:

Capa de Interacción con el usuario (Interfaz grafica): Esta capa va a ser la que recoja los datos que ingresa el usuario y a su vez muestra por pantalla los referentes outputs.Cuando un usuario ingresa informacion, esta se traduce y se comunica con la Capa de Modelo de negocio. Para implementarla usaremos un poryecto de tipo Windows Forms.
Capa de Modelo del Negocio: Recibe la informacion ingresada por el usuario, aplica validaciones, calculos y reglas del negocio sobre ella. Su función es transformar los datos en acciones sobre el modelo. Luego se comunica con la siguiente capa. Para implementarla usaremos una Biblioteca de Clases.
Capa de persistencia (conexión a la Base de Datos): Se encarga de la interacción con la base de datos. Traduce las clases en tablas donde se va a almacenar los datos recogidos. Esto se logra realizando correctamente las migraciones con el Entity Framework (mapeador). Para implementarla usaremos Repositorios, que son una clase que sirve como intermediaria entre la Logica de negocio y la base de datos. La clase ApplicationDbContext, que hereda de DbContext, es la que realiza la coneccion con la base de datos y define las tablas.
Link del diagrama de clases: - https://drive.google.com/file/d/1PKeG6zoc04bshShxsDWsvIrv7a3FgKA_/view?usp=sharing
