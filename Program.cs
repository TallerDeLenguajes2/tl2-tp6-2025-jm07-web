using Microsoft.Data.Sqlite;
/*string connectionString = "Data Source=base_test.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }
    
    // Insertar datos
    string insertQuery = "INSERT INTO productos (nombre, precio) VALUES ('Manzana', 0.50), ('Banana', 0.30)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'productos'.");
            }
    // Leer datos
            string selectQuery = "SELECT * FROM productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nombre: {reader["nombre"]}, Precio: {reader["precio"]}");
                }
            }

            connection.Close();
}*/

//Conexion con mi base de datos
string connectionString = "Data Source=Tienda.db;";

// Crear conexión a la base de datos 
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();

    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (IdProducto INTEGER PRIMARY KEY UNIQUE, Descripcion TEXT, Precio NUMERIC(10,2))";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }

    string createTableQuery1 = "CREATE TABLE IF NOT EXISTS presupuestos (IdPresupuesto INTEGER PRIMARY KEY UNIQUE, NombreDestinatario TEXT(100), FechaCreacion TEXT)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery1, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'presupuestos' creada o ya existe.");
    }

    string createTableQuery2 = "CREATE TABLE IF NOT EXISTS presupuestosDetalle (IdPresupuesto INTEGER, IdProducto INTEGER, Cantidad INTEGER, PRIMARY KEY (IdPresupuesto, IdProducto), FOREIGN KEY (IdPresupuesto) REFERENCES presupuestos(IdPresupuesto), FOREIGN KEY (IdProducto) REFERENCES productos(IdProducto))";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery2, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'presupuestosDetalle' creada o ya existe.");
    }
    
    // Insertar datos
    string insertQuery = "INSERT INTO productos (Descripcion, Precio) VALUES ('Mouse Inalámbrico', 5000.0)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'productos'.");
            }
    
    string insertQuery1 = "INSERT INTO presupuestos (NombreDestinatario, FechaCreacion) VALUES ('Carlos Ruiz', '2024-10-25')";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery1, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'presupuestos'.");
            }
    
    string insertQuery2 = "INSERT INTO presupuestosDetalle (IdPresupuesto, IdProducto, Cantidad) VALUES (1, 1, 2)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery2, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'presupuestosDetalle'.");
            }

    //Modificar datos
    string updateQuery = "UPDATE productos SET Descripcion = 'Teclado Mecánico Logitech', Precio = 12000 WHERE IdProducto = 3";
        using (SqliteCommand updateCmd = new SqliteCommand(updateQuery, connection))
        {
            updateCmd.ExecuteNonQuery();
            Console.WriteLine("Datos actualizados en la tabla 'productos'.");
        }

    string updateQuery1 = "UPDATE presupuestos SET NombreDestinatario = 'Luis Fernández' WHERE IdPresupuesto = 1";
        using (SqliteCommand updateCmd = new SqliteCommand(updateQuery1, connection))
        {
            updateCmd.ExecuteNonQuery();
            Console.WriteLine("Datos actualizados en la tabla 'presupuestos'.");
        }

    //Eliminar datos
    string deleteQuery = "DELETE FROM presupuestosDetalle WHERE IdPresupuesto = 1 AND IdProducto = 2;";
        using (SqliteCommand deleteCmd = new SqliteCommand(deleteQuery, connection))
        {
            deleteCmd.ExecuteNonQuery();
            Console.WriteLine("Datos eliminados en la tabla 'presupuestosDetalle'.");
        }

    // Leer datos
            string selectQuery = "SELECT * FROM productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["IdProducto"]}, Nombre: {reader["Descripcion"]}, Precio: {reader["Precio"]}");
                }
            }

            connection.Close();
}