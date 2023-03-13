using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Core.DataAccess.SocketSystems.Concrete.TCP
{
    public delegate void OnExampleDTOReceived(Byte[] eDTO);
    public class Client
    {
        #region Variables
        public OnExampleDTOReceived _OnExampleDTOReceived;
        Socket _Socket;

        // Socket işlemleri sırasında oluşabilecek errorları bu enum ile handle edebiliriz.
        SocketError socketError;
        byte[] tempBuffer = new byte[1024]; // 1024 boyutunda temp bir buffer, gelen verinin boyutu kadarıyla bunu receive kısmında handle edeceğiz.
        #endregion

        #region Constructor
        public Client(Socket socket)
        {
            _Socket = socket;
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            // Socket üzerinden data dinlemeye başlıyoruz.
            _Socket.BeginReceive(tempBuffer, 0, tempBuffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
        }
        #endregion

        #region Private Methods
        void OnBeginReceiveCallback(IAsyncResult asyncResult)
        {
            // Almayı bitiriyoruz ve gelen byte array'in boyutunu vermektedir.
            int receivedDataLength = _Socket.EndReceive(asyncResult, out socketError);

            if (receivedDataLength <= 0 && socketError != SocketError.Success)
            {
                // Gelen byte array verisi boş ise bağlantı kopmuş demektir. Burayı istediğiniz gibi handle edebilirsiniz.
                return;
            }

            // Gelen byte array boyutunda yeni bir byte array oluşturuyoruz.
            byte[] resizedBuffer = new byte[receivedDataLength];

            Array.Copy(tempBuffer, 0, resizedBuffer, 0, resizedBuffer.Length);

            // Gelen datayı burada ele alacağız.
            HandleReceivedData(resizedBuffer);

            // Tekrardan socket üzerinden data dinlemeye başlıyoruz.
            // Start();

            // Socket üzerinden data dinlemeye başlıyoruz.
            _Socket.BeginReceive(tempBuffer, 0, tempBuffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
        }

        /// <summary>
        /// Gelen datayı handle edeceğimiz nokta.
        /// </summary>
        /// <param name="resizedBuffer"></param>
        void HandleReceivedData(byte[] resizedBuffer)
        {
            if (_OnExampleDTOReceived != null)
            {
                using (var ms = new MemoryStream(resizedBuffer))
                {
                    Console.WriteLine(Encoding.UTF8.GetString(resizedBuffer));
                   
                }
            }
        }
        #endregion
    }
}
