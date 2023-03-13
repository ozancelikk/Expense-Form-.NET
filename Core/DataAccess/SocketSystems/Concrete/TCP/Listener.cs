using Core.DataAccess.SocketSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Core.DataAccess.SocketSystems.Concrete.TCP
{
    public class Listener
    {
        #region Variables
        Socket _Socket;
        int _Port;
        int _MaxConnectionQueue;
        #endregion

        #region Constructor
        public Listener(int port, int maxConnectionQueue)
        {
            _Port = port;
            _MaxConnectionQueue = maxConnectionQueue;

            // Socket'i tanımlıyoruz IPv4, socket tipimiz stream olacak ve TCP Protokolü ile haberleşeceğiz. 
            // TCP Protokolünde server belirlenen portu dinler ve gelen istekleri karşılar oysaki UDP Protokolünde tek bir socket üzerinden birden çok client'a ulaşmak mümkündür.
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, _Port);

            // Socket'e herhangi bir yerden ve belirttiğimiz porttan gelecek olan bağlantıları belirtmeliyiz.
            _Socket.Bind(ipEndPoint);

            // Socketten gelecek olan bağlantıları dinlemeye başlıyoruz ve maksimum dinleyeceği bağlantıyı belirtiyoruz.
            _Socket.Listen(_MaxConnectionQueue);

            // BeginAccept ile asenkron olarak gelen bağlantıları kabul ediyoruz.         
            _Socket.BeginAccept(OnBeginAccept, _Socket);
        }
        #endregion

        #region Private Methods
        void OnBeginAccept(IAsyncResult asyncResult)
        {
            Socket socket = _Socket.EndAccept(asyncResult);
            Client client = new Client(socket);

            // Client tarafından gönderilen datamızı işleyeceğimiz kısım.
            client._OnExampleDTOReceived += new Core.DataAccess.SocketSystems.Concrete.TCP.OnExampleDTOReceived(OnExampleDTOReceived);
            client.Start();

            // Tekrardan dinlemeye devam diyoruz.
            _Socket.BeginAccept(OnBeginAccept, null);
        }

        void OnExampleDTOReceived(byte[] exampleDTO)
        {
            // Client tarafından gelen data, istediğiniz gibi burada handle edebilirsiniz senaryonuza göre.
    
        }
        #endregion
    }
}
