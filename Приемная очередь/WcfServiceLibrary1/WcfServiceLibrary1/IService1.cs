using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<enrollee> vivod();

        [OperationContract]
        bool dobav(string surname, string name, string patronymic, string date_coming, string time_coming, string date_call, string time_call, string status, string turn);

        [OperationContract]
        bool dobav1(string Id_type_status, string Id_cash, string date_status, string tame_status);

        [OperationContract]
        string getidstatus (string idts, string casa, string ds, string ts);
       
        [OperationContract]
        List<string> vozvr_spis();

        [OperationContract]
        List<bool> actcash();

        [OperationContract]
        bool actact(int number_cash, int type);

        [OperationContract]
        bool cash_off(int number_cash);

        [OperationContract]
        int turn_cash(int cash);


        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

    }

    [DataContract]
    public class enrollee
    {
        [DataMember]
        public string surname { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string patronymic { get; set; }
        [DataMember]
        public string date_coming { get; set; }
        [DataMember]
        public string time_coming { get; set; }
        [DataMember]
        public string date_call { get; set; }
        [DataMember]
        public string time_call { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string turn { get; set; }
        [DataMember]
        public string cash { get; set; }
    }

    [DataContract]
    public class activcash
    {
        [DataMember]
        public bool numc1 { get; set; }
        //public bool numc2 { get; set; }
        //public bool numc3 { get; set; }
        //public bool numc4 { get; set; }
        //public bool numc5 { get; set; }
        //public bool numc6 { get; set; }
    }



}
