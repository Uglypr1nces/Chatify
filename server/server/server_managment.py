import socket


class Server:
    def __init__(self, server_socket,FORMAT,HEADER):
        self.server_socket = server_socket
        self.connections = []
        self.FORMAT = FORMAT
        self.HEADER = HEADER

    def add_connection(self, conn, addr):
        self.connections.append((conn))

    def send_message(self, conn, msg):
        try:
            message = msg.encode(self.FORMAT)
            conn.send(message)
        except:
            print("error with sending message")

    def handle_client(self, conn, addr):
        connected = True
        try:
            while connected:
                msg = conn.recv(1024).decode(self.FORMAT)
                if msg == "!disc":
                    self.connections.remove(conn)
                    connected = False
                for connection in self.connections:
                    self.send_message(connection,msg)
                print(msg)

        except ConnectionResetError:
            print(f"Connection with {addr} was forcibly closed.")
        finally:
            conn.close()