//
// CommandDatagram.cs
//
// Author:
//       PFactor.io <admin@pfactor.io>
//
// Copyright (c) 2015 PFactor.io
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Text;
using log4net;

namespace XPiPlane
{
	public class CommandDatagram : IXPDatagram
	{
		private int type;
		private string opcode;
		private string payload;
		private readonly ILog log;

		public int Type
		{
			get
			{
				return type;
			}
		}

		public string OpCode { 
			get
			{
				return opcode;
			}
		}

		public string Payload
		{
			get
			{
				return payload;
			}
			set
			{
				payload = value;
			}
		}

		public CommandDatagram()
		{
			this.type = (int) XPiPlaneConstants.DatagramTypes.COMMAND;
			this.opcode = "CMND0";
			log = LogManager.GetLogger(opcode.Substring(0, 4));
			log.Debug("New XP Command Created");
		}

		public string ComposeMessage()
		{
			StringBuilder sb = new StringBuilder(opcode);
			sb.Append(payload);
			return sb.ToString();
		}
		
		public byte[] Marshall(string message)
		{
			byte[] encodedMessage = new byte[0];

			if (message != null)
			{
				encodedMessage = Encoding.ASCII.GetBytes(message);
				log.Debug("Marshalled: " + XPiPlaneConstants.PrintByteArray(encodedMessage));
			}

			return encodedMessage;
		}

		public string UnMarshall(byte[] message)
		{
			throw new NotImplementedException("CMND.UnMarshall() is not implemented");
		}
	}
}

