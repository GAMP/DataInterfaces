using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetLib
{
    public delegate void ConnectionEventDelegate(IConnection sender);    
    public delegate void EndpointEventDelegate(IConnection sender, EndPoint endpoint);    
    public delegate void NewConnectionDelegate(IConnection sender, Socket socket);    
    public delegate void ConnectionExceptionDelegate(IConnection sender, Exception ex);    
    public delegate void SentRecieveDelegate(IConnection sender, byte[] buffer);    
    public delegate void SendingReceivingDelegate(IConnection sender, byte[] buffer, int offset, int size, int dataLeft);
    public delegate void CommandsReceivedDelegate(IConnection sender, List<ISmartlaunchCommand> commands);
}
