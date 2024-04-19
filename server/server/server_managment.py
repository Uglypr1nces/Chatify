import socket


class Server:
    def __init__(self, server_socket,FORMAT,HEADER):
        self.server_socket = server_socket
        self.connections = []
        self.usernames = []
        self.FORMAT = FORMAT
        self.HEADER = HEADER

    def add_connection(self, conn, addr):
        self.connections.append((conn))

    def send_message(self, conn, msg):
        try:
            message = msg.encode(self.FORMAT)
            conn.send(message)
        except:
            self.connections.remove(conn)
            print(f"error with sending message, {conn} has been removed, {len(self.connections)} amount of connections")
            message = f"afXMZhjvchs88vjls.g87satv0q,.7fg{len(self.connections)}"
            for connection in self.connections:
                self.send_message(connection, message)
                self.send_message(connection, f"someone disconnected")


    def handle_client(self, conn, addr):
        connected = True
        try:
            while connected:
                msg = conn.recv(1024).decode(self.FORMAT)
                if msg == "!disc":
                    conn.close()
                    self.connections.remove(conn)
                    connected = False
                elif "a90sd7f8jmvsdf0sdf8asdf87a/(&()/=%?" in msg:
                    username = msg[35:]
                    self.usernames.append(username)
                    for connection in self.connections:
                        self.send_message(connection, f"{username} has joined the chat")
                else:
                    for connection in self.connections:
                        self.send_message(connection,msg)
                    print(msg)

        except ConnectionResetError:
            print(f"Connection with {addr} was forcibly closed.")
        finally:
            conn.close()