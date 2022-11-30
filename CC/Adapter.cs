using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC
{
    public class Adapter
    {

    }

    public static class CurrentWorker
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Passport { get; set; }
        public static DateTime Birth { get; set; }
        public static char Gen { get; set; }
        public static string Job { get; set; }
        public static int Stage { get; set; }
        public static string Phone { get; set; }
        public static string Mail { get; set; }

        public static bool Login(string phone, string pwd)
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand WorkerLogin = new System.Data.SqlClient.SqlCommand("SELECT * FROM WorkerLogin(@Phone, @Id)", DBConnection.connection);
            WorkerLogin.CommandType = System.Data.CommandType.Text;

            WorkerLogin.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 40);
            WorkerLogin.Parameters["@Phone"].Value = phone;

            WorkerLogin.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 40);
            WorkerLogin.Parameters["@Id"].Value = pwd;

            DBConnection.Open();
            resultTable.Load(WorkerLogin.ExecuteReader());
            DBConnection.Close();

            if (resultTable.Rows.Count > 0)
            {
                Id = int.Parse(resultTable.Rows[0][0].ToString());
                Name = resultTable.Rows[0][1].ToString();
                Passport = resultTable.Rows[0][2].ToString() + " " + resultTable.Rows[0][3].ToString();
                Birth = DateTime.Parse(resultTable.Rows[0][4].ToString());
                Gen = char.Parse(resultTable.Rows[0][5].ToString());
                Job = resultTable.Rows[0][6].ToString();
                Stage = int.Parse(resultTable.Rows[0][7].ToString());
                Phone = resultTable.Rows[0][8].ToString();
                Mail = resultTable.Rows[0][9].ToString();
                return true;
            }
            else
                return false;
        }
    }

    public static class Workers
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllWorkers = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllWorkers()", DBConnection.connection);
            GetAllWorkers.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllWorkers.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static DataTable GetByBrigadeId(int id)
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetWorkersByBrigadeId = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetWorkersByBrigadeId(@id)", DBConnection.connection);
            GetWorkersByBrigadeId.CommandType = System.Data.CommandType.Text;

            GetWorkersByBrigadeId.Parameters.Add("@id", System.Data.SqlDbType.Int);
            GetWorkersByBrigadeId.Parameters["@id"].Value = id;

            DBConnection.Open();
            resultTable.Load(GetWorkersByBrigadeId.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptyWorker = new System.Data.SqlClient.SqlCommand("AddEmptyWorker", DBConnection.connection);

            DBConnection.Open();
            AddEmptyWorker.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Clients
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllClients = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllClients()", DBConnection.connection);
            GetAllClients.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllClients.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptyClient = new System.Data.SqlClient.SqlCommand("AddEmptyClient", DBConnection.connection);

            DBConnection.Open();
            AddEmptyClient.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Materials
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllMaterials = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllMaterials()", DBConnection.connection);
            GetAllMaterials.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllMaterials.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptyMaterial = new System.Data.SqlClient.SqlCommand("AddEmptyMaterial", DBConnection.connection);

            DBConnection.Open();
            AddEmptyMaterial.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Deliveries
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllDeliveries = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllDeliveries()", DBConnection.connection);
            GetAllDeliveries.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllDeliveries.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add(int supId, int matId, int count)
        {
            System.Data.SqlClient.SqlCommand AddDelivery = new System.Data.SqlClient.SqlCommand("AddDelivery", DBConnection.connection);
            AddDelivery.CommandType = System.Data.CommandType.StoredProcedure;
            AddDelivery.Parameters.Add("@SupId", System.Data.SqlDbType.Int);
            AddDelivery.Parameters["@SupId"].Value = supId;

            AddDelivery.Parameters.Add("@MatId", System.Data.SqlDbType.Int);
            AddDelivery.Parameters["@MatId"].Value = matId;

            AddDelivery.Parameters.Add("@Count", System.Data.SqlDbType.Int);
            AddDelivery.Parameters["@Count"].Value = count;

            DBConnection.Open();
            AddDelivery.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Suppliers
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllSuppliers = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllSuppliers()", DBConnection.connection);
            GetAllSuppliers.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllSuppliers.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptySupplier = new System.Data.SqlClient.SqlCommand("AddEmptySupplier", DBConnection.connection);

            DBConnection.Open();
            AddEmptySupplier.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Brigades
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllBrigades = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllBrigades()", DBConnection.connection);
            GetAllBrigades.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllBrigades.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptyBrigade = new System.Data.SqlClient.SqlCommand("AddEmptyBrigade", DBConnection.connection);

            DBConnection.Open();
            AddEmptyBrigade.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Projects
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllProjects = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllProjects()", DBConnection.connection);
            GetAllProjects.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllProjects.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }

        public static void Add()
        {
            System.Data.SqlClient.SqlCommand AddEmptyProject = new System.Data.SqlClient.SqlCommand("AddEmptyProject", DBConnection.connection);

            DBConnection.Open();
            AddEmptyProject.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public static class Works
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllWorks = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllWorks()", DBConnection.connection);
            GetAllWorks.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllWorks.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }
    }

    public static class CompletedWorks
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllCompletedWorks = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllCompletedWorks()", DBConnection.connection);
            GetAllCompletedWorks.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllCompletedWorks.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }
    }

    public static class MatCons
    {
        public static DataTable GetAll()
        {
            var resultTable = new DataTable();
            System.Data.SqlClient.SqlCommand GetAllMatCons = new System.Data.SqlClient.SqlCommand("SELECT * FROM GetAllMatCons()", DBConnection.connection);
            GetAllMatCons.CommandType = System.Data.CommandType.Text;

            DBConnection.Open();
            resultTable.Load(GetAllMatCons.ExecuteReader());
            DBConnection.Close();

            return resultTable;
        }
    }

    public class MatCon
    {
        public int MatId { get; set; }
        public int WorkId { get; set; }
        public int Count { get; set; }

        public MatCon(int matId, int workId, int count)

        {
            MatId = matId;
            WorkId = workId;
            Count = count;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateMatCon = new System.Data.SqlClient.SqlCommand("UpdateMatCon", DBConnection.connection);
            UpdateMatCon.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateMatCon.Parameters.Add("@MatId", System.Data.SqlDbType.Int);
            UpdateMatCon.Parameters["@MatId"].Value = MatId;

            UpdateMatCon.Parameters.Add("@WorkId", System.Data.SqlDbType.Int);
            UpdateMatCon.Parameters["@WorkId"].Value = WorkId;

            UpdateMatCon.Parameters.Add("@Count", System.Data.SqlDbType.Int);
            UpdateMatCon.Parameters["@Count"].Value = Count;

            DBConnection.Open();
            try
            {
                UpdateMatCon.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            DBConnection.Close();
        }

        public void Delete()
        {
            System.Data.SqlClient.SqlCommand DeleteMatCon = new System.Data.SqlClient.SqlCommand("DeleteMatCon", DBConnection.connection);
            DeleteMatCon.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteMatCon.Parameters.Add("@MatId", System.Data.SqlDbType.Int);
            DeleteMatCon.Parameters["@MatId"].Value = MatId;

            DeleteMatCon.Parameters.Add("@WorkId", System.Data.SqlDbType.Int);
            DeleteMatCon.Parameters["@WorkId"].Value = WorkId;

            DBConnection.Open();
            DeleteMatCon.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void Add()
        {
            System.Data.SqlClient.SqlCommand AddMatCon = new System.Data.SqlClient.SqlCommand("AddMatCon", DBConnection.connection);
            AddMatCon.CommandType = System.Data.CommandType.StoredProcedure;

            AddMatCon.Parameters.Add("@MatId", System.Data.SqlDbType.Int);
            AddMatCon.Parameters["@MatId"].Value = MatId;

            AddMatCon.Parameters.Add("@WorkId", System.Data.SqlDbType.Int);
            AddMatCon.Parameters["@WorkId"].Value = WorkId;

            AddMatCon.Parameters.Add("@Count", System.Data.SqlDbType.Int);
            AddMatCon.Parameters["@Count"].Value = Count;

            DBConnection.Open();
            try
            {
                AddMatCon.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            DBConnection.Close();
        }

    }

    public class CompletedWork
    {
        public int ProjId { get; set; }
        public int WorkId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }

        public CompletedWork(int projId, int workId, DateTime start, DateTime end, string status)
        {
            ProjId = projId;
            WorkId = workId;
            Start = start;
            End = end;
            Status = status;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateCompletedWork = new System.Data.SqlClient.SqlCommand("UpdateCompletedWork", DBConnection.connection);
            UpdateCompletedWork.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateCompletedWork.Parameters.Add("@ProjId", System.Data.SqlDbType.Int);
            UpdateCompletedWork.Parameters["@ProjId"].Value = ProjId;

            UpdateCompletedWork.Parameters.Add("@WorkId", System.Data.SqlDbType.Int);
            UpdateCompletedWork.Parameters["@WorkId"].Value = WorkId;

            UpdateCompletedWork.Parameters.Add("@Start", System.Data.SqlDbType.Date);
            UpdateCompletedWork.Parameters["@Start"].Value = Start;

            UpdateCompletedWork.Parameters.Add("@End", System.Data.SqlDbType.Date);
            UpdateCompletedWork.Parameters["@End"].Value = End;

            UpdateCompletedWork.Parameters.Add("@Status", System.Data.SqlDbType.VarChar, 20);
            UpdateCompletedWork.Parameters["@Status"].Value = Status;

            DBConnection.Open();
            UpdateCompletedWork.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void Add()
        {
            System.Data.SqlClient.SqlCommand AddCompletedWork = new System.Data.SqlClient.SqlCommand("AddCompletedWork", DBConnection.connection);
            AddCompletedWork.CommandType = System.Data.CommandType.StoredProcedure;

            AddCompletedWork.Parameters.Add("@ProjId", System.Data.SqlDbType.Int);
            AddCompletedWork.Parameters["@ProjId"].Value = ProjId;

            AddCompletedWork.Parameters.Add("@WorkId", System.Data.SqlDbType.Int);
            AddCompletedWork.Parameters["@WorkId"].Value = WorkId;

            AddCompletedWork.Parameters.Add("@Start", System.Data.SqlDbType.Date);
            AddCompletedWork.Parameters["@Start"].Value = Start;

            AddCompletedWork.Parameters.Add("@End", System.Data.SqlDbType.Date);
            AddCompletedWork.Parameters["@End"].Value = End;

            AddCompletedWork.Parameters.Add("@Status", System.Data.SqlDbType.VarChar, 20);
            AddCompletedWork.Parameters["@Status"].Value = Status;

            DBConnection.Open();
            AddCompletedWork.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrId { get; set; }
        public string Type { get; set; }

        public Work (int id, int brId, string type, string name)
        {
            Id = id;
            BrId = brId;
            Type = type;
            Name = name;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateWork = new System.Data.SqlClient.SqlCommand("UpdateWork", DBConnection.connection);
            UpdateWork.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateWork.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateWork.Parameters["@Id"].Value = Id;

            UpdateWork.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 60);
            UpdateWork.Parameters["@Name"].Value = Name;

            UpdateWork.Parameters.Add("@Type", System.Data.SqlDbType.VarChar, 50);
            UpdateWork.Parameters["@Type"].Value = Type;

            UpdateWork.Parameters.Add("@BrId", System.Data.SqlDbType.Int);
            UpdateWork.Parameters["@BrId"].Value = BrId;

            DBConnection.Open();
            UpdateWork.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void Add()
        {
            System.Data.SqlClient.SqlCommand AddWork = new System.Data.SqlClient.SqlCommand("AddWork", DBConnection.connection);
            AddWork.CommandType = System.Data.CommandType.StoredProcedure;

            AddWork.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 60);
            AddWork.Parameters["@Name"].Value = Name;

            AddWork.Parameters.Add("@Type", System.Data.SqlDbType.VarChar, 50);
            AddWork.Parameters["@Type"].Value = Type;

            AddWork.Parameters.Add("@BrId", System.Data.SqlDbType.Int);
            AddWork.Parameters["@BrId"].Value = BrId;

            DBConnection.Open();
            AddWork.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PasSeries { get; set; }
        public int PasNum { get; set; }
        public DateTime Birth { get; set; }
        public char Gen { get; set; }
        public string Job { get; set; }
        public int Stage { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Worker(int id, string name, int pasSeries, int pasNum,
            DateTime birth, char gen, string job, int stage, string phone, string mail)
        {
            Id = id;
            Name = name;
            PasSeries = pasSeries;
            PasNum = pasNum;
            Birth = birth;
            Gen = gen;
            Job = job;
            Stage = stage;
            Phone = phone;
            Mail = mail;
        }

        public bool Update()
        {
            System.Data.SqlClient.SqlCommand UpdateWorker = new System.Data.SqlClient.SqlCommand("UpdateWorker", DBConnection.connection);
            UpdateWorker.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateWorker.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateWorker.Parameters["@Id"].Value = Id;

            UpdateWorker.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            UpdateWorker.Parameters["@Name"].Value = Name;

            UpdateWorker.Parameters.Add("@PasSeries", System.Data.SqlDbType.VarChar, 10);
            UpdateWorker.Parameters["@PasSeries"].Value = PasSeries;

            UpdateWorker.Parameters.Add("@PasNum", System.Data.SqlDbType.VarChar, 20);
            UpdateWorker.Parameters["@PasNum"].Value = PasNum;

            UpdateWorker.Parameters.Add("@Birth", System.Data.SqlDbType.Date);
            UpdateWorker.Parameters["@Birth"].Value = Birth;

            UpdateWorker.Parameters.Add("@Gen", System.Data.SqlDbType.Char, 1);
            UpdateWorker.Parameters["@Gen"].Value = Gen;

            UpdateWorker.Parameters.Add("@Job", System.Data.SqlDbType.VarChar, 30);
            UpdateWorker.Parameters["@Job"].Value = Job;

            UpdateWorker.Parameters.Add("@Stage", System.Data.SqlDbType.Int);
            UpdateWorker.Parameters["@Stage"].Value = Stage;

            UpdateWorker.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 30);
            UpdateWorker.Parameters["@Phone"].Value = Phone;

            UpdateWorker.Parameters.Add("@Mail", System.Data.SqlDbType.VarChar, 30);
            UpdateWorker.Parameters["@Mail"].Value = Mail;

            UpdateWorker.Parameters.Add("@Response", System.Data.SqlDbType.Int);
            UpdateWorker.Parameters["@Response"].Direction = ParameterDirection.Output;

            DBConnection.Open();
            UpdateWorker.ExecuteNonQuery();
            DBConnection.Close();

            return int.Parse(UpdateWorker.Parameters["@Response"].Value.ToString()) == 0;
        }

        public void Delete()
        {
            System.Data.SqlClient.SqlCommand DeleteWorker = new System.Data.SqlClient.SqlCommand("DeleteWorker", DBConnection.connection);
            DeleteWorker.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteWorker.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            DeleteWorker.Parameters["@Id"].Value = Id;

            DBConnection.Open();
            DeleteWorker.ExecuteNonQuery();
            DBConnection.Close();

        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PasSeries { get; set; }
        public int PasNum { get; set; }
        public DateTime Birth { get; set; }
        public char Gen { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Client(int id, string name, int pasSeries, int pasNum,
            DateTime birth, char gen, string phone, string mail)
        {
            Id = id;
            Name = name;
            PasSeries = pasSeries;
            PasNum = pasNum;
            Birth = birth;
            Gen = gen;
            Phone = phone;
            Mail = mail;
        }

        public bool Update()
        {
            System.Data.SqlClient.SqlCommand UpdateClient = new System.Data.SqlClient.SqlCommand("UpdateClient", DBConnection.connection);
            UpdateClient.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateClient.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateClient.Parameters["@Id"].Value = Id;

            UpdateClient.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            UpdateClient.Parameters["@Name"].Value = Name;

            UpdateClient.Parameters.Add("@PasSeries", System.Data.SqlDbType.VarChar, 10);
            UpdateClient.Parameters["@PasSeries"].Value = PasSeries;

            UpdateClient.Parameters.Add("@PasNum", System.Data.SqlDbType.VarChar, 20);
            UpdateClient.Parameters["@PasNum"].Value = PasNum;

            UpdateClient.Parameters.Add("@Birth", System.Data.SqlDbType.Date);
            UpdateClient.Parameters["@Birth"].Value = Birth;

            UpdateClient.Parameters.Add("@Gen", System.Data.SqlDbType.Char, 1);
            UpdateClient.Parameters["@Gen"].Value = Gen;

            UpdateClient.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 30);
            UpdateClient.Parameters["@Phone"].Value = Phone;

            UpdateClient.Parameters.Add("@Mail", System.Data.SqlDbType.VarChar, 30);
            UpdateClient.Parameters["@Mail"].Value = Mail;

            UpdateClient.Parameters.Add("@Response", System.Data.SqlDbType.Int);
            UpdateClient.Parameters["@Response"].Direction = ParameterDirection.Output;

            DBConnection.Open();
            UpdateClient.ExecuteNonQuery();
            DBConnection.Close();

            return int.Parse(UpdateClient.Parameters["@Response"].Value.ToString()) == 0;
        }

        public void Delete()
        {
            System.Data.SqlClient.SqlCommand DeleteClient = new System.Data.SqlClient.SqlCommand("DeleteClient", DBConnection.connection);
            DeleteClient.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteClient.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            DeleteClient.Parameters["@Id"].Value = Id;

            DBConnection.Open();
            DeleteClient.ExecuteNonQuery();
            DBConnection.Close();

        }
    }

    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ed { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public Material(int id, string name, string ed, decimal price, int count)
        {
            this.Id = id;
            this.Name = name;
            this.Ed = ed;
            this.Price = price;
            this.Count = count;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateMaterial = new System.Data.SqlClient.SqlCommand("UpdateMaterial", DBConnection.connection);
            UpdateMaterial.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateMaterial.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateMaterial.Parameters["@Id"].Value = Id;

            UpdateMaterial.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            UpdateMaterial.Parameters["@Name"].Value = Name;

            UpdateMaterial.Parameters.Add("@Ed", System.Data.SqlDbType.VarChar, 10);
            UpdateMaterial.Parameters["@Ed"].Value = Ed;

            UpdateMaterial.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
            UpdateMaterial.Parameters["@Price"].Value = Price;

            DBConnection.Open();
            UpdateMaterial.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void Delete()
        {
            System.Data.SqlClient.SqlCommand DeleteMaterial = new System.Data.SqlClient.SqlCommand("DeleteMaterial", DBConnection.connection);
            DeleteMaterial.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteMaterial.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            DeleteMaterial.Parameters["@Id"].Value = Id;

            DBConnection.Open();
            DeleteMaterial.ExecuteNonQuery();
            DBConnection.Close();

        }
    }

    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Supplier(int id, string name, string company, string address, string phone, string mail)
        {
            Id = id;
            Name = name;
            Company = company;
            Address = address;
            Phone = phone;
            Mail = mail;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateSupplier = new System.Data.SqlClient.SqlCommand("UpdateSupplier", DBConnection.connection);
            UpdateSupplier.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateSupplier.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateSupplier.Parameters["@Id"].Value = Id;

            UpdateSupplier.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            UpdateSupplier.Parameters["@Name"].Value = Name;

            UpdateSupplier.Parameters.Add("@Company", System.Data.SqlDbType.VarChar, 30);
            UpdateSupplier.Parameters["@Company"].Value = Company;

            UpdateSupplier.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 50);
            UpdateSupplier.Parameters["@Address"].Value = Address;

            UpdateSupplier.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 30);
            UpdateSupplier.Parameters["@Phone"].Value = Phone;

            UpdateSupplier.Parameters.Add("@Mail", System.Data.SqlDbType.VarChar, 30);
            UpdateSupplier.Parameters["@Mail"].Value = Mail;

            DBConnection.Open();
            UpdateSupplier.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void Delete()
        {
            System.Data.SqlClient.SqlCommand DeleteSupplier = new System.Data.SqlClient.SqlCommand("DeleteSupplier", DBConnection.connection);
            DeleteSupplier.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteSupplier.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            DeleteSupplier.Parameters["@Id"].Value = Id;

            DBConnection.Open();
            DeleteSupplier.ExecuteNonQuery();
            DBConnection.Close();

        }
    }

    public class Brigade
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public Brigade (int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update()
        {
            System.Data.SqlClient.SqlCommand UpdateBrigade = new System.Data.SqlClient.SqlCommand("UpdateBrigade", DBConnection.connection);
            UpdateBrigade.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateBrigade.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateBrigade.Parameters["@Id"].Value = Id;

            UpdateBrigade.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 30);
            UpdateBrigade.Parameters["@Name"].Value = Name;

            DBConnection.Open();
            UpdateBrigade.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void AddWorker(int workerId)
        {
            System.Data.SqlClient.SqlCommand AddWorkerToBrigade = new System.Data.SqlClient.SqlCommand("AddWorkerToBrigade", DBConnection.connection);
            AddWorkerToBrigade.CommandType = System.Data.CommandType.StoredProcedure;
            AddWorkerToBrigade.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            AddWorkerToBrigade.Parameters["@Id"].Value = Id;

            AddWorkerToBrigade.Parameters.Add("@workerId", System.Data.SqlDbType.Int);
            AddWorkerToBrigade.Parameters["@workerId"].Value = workerId;

            DBConnection.Open();
            AddWorkerToBrigade.ExecuteNonQuery();
            DBConnection.Close();
        }

        public void DeleteWorker (int workerId)
        {
            System.Data.SqlClient.SqlCommand DeleteWorkerFromBrigade = new System.Data.SqlClient.SqlCommand("DeleteWorkerFromBrigade", DBConnection.connection);
            DeleteWorkerFromBrigade.CommandType = System.Data.CommandType.StoredProcedure;
            DeleteWorkerFromBrigade.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            DeleteWorkerFromBrigade.Parameters["@Id"].Value = Id;

            DeleteWorkerFromBrigade.Parameters.Add("@workerId", System.Data.SqlDbType.Int);
            DeleteWorkerFromBrigade.Parameters["@workerId"].Value = workerId;

            DBConnection.Open();
            DeleteWorkerFromBrigade.ExecuteNonQuery();
            DBConnection.Close();
        }
    }

    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WorkerId { get; set; }
        public string Descr { get; set; }
        public string Addr { get; set; }
        public decimal Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Doc { get; set; }

        public Project (int id, int clientId, int workerId, string descr,
            string addr, decimal price, DateTime start, DateTime end, string status,
            string type, string doc)
        {
            Id = id;
            ClientId = clientId;
            WorkerId = workerId;
            Descr = descr;
            Addr = addr;
            Price = price;
            Start = start;
            End = end;
            Status = status;
            Type = type;
            Doc = doc;
        }

        public bool Update()
        {
            System.Data.SqlClient.SqlCommand UpdateProject = new System.Data.SqlClient.SqlCommand("UpdateProject", DBConnection.connection);
            UpdateProject.CommandType = System.Data.CommandType.StoredProcedure;
            UpdateProject.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            UpdateProject.Parameters["@Id"].Value = Id;

            UpdateProject.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
            UpdateProject.Parameters["@ClientId"].Value = ClientId;

            UpdateProject.Parameters.Add("@WorkerId", System.Data.SqlDbType.Int);
            UpdateProject.Parameters["@WorkerId"].Value = WorkerId;

            UpdateProject.Parameters.Add("@Descr", System.Data.SqlDbType.VarChar, 80);
            UpdateProject.Parameters["@Descr"].Value = Descr;

            UpdateProject.Parameters.Add("@Addr", System.Data.SqlDbType.VarChar, 50);
            UpdateProject.Parameters["@Addr"].Value = Addr;

            UpdateProject.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
            UpdateProject.Parameters["@Price"].Value = Price;

            UpdateProject.Parameters.Add("@Start", System.Data.SqlDbType.Date);
            UpdateProject.Parameters["@Start"].Value = Start;

            UpdateProject.Parameters.Add("@End", System.Data.SqlDbType.Date);
            UpdateProject.Parameters["@End"].Value = End;

            UpdateProject.Parameters.Add("@Status", System.Data.SqlDbType.VarChar, 10);
            UpdateProject.Parameters["@Status"].Value = Status;

            UpdateProject.Parameters.Add("@Type", System.Data.SqlDbType.VarChar, 40);
            UpdateProject.Parameters["@Type"].Value = Type;

            UpdateProject.Parameters.Add("@Doc", System.Data.SqlDbType.VarChar, 10);
            UpdateProject.Parameters["@Doc"].Value = Doc;

            UpdateProject.Parameters.Add("@Response", System.Data.SqlDbType.Int);
            UpdateProject.Parameters["@Response"].Direction = ParameterDirection.Output;

            DBConnection.Open();
            UpdateProject.ExecuteNonQuery();
            DBConnection.Close();

            return int.Parse(UpdateProject.Parameters["@Response"].Value.ToString()) == 0;
        }
    }

}
