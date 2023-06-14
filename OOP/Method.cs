namespace OOP
{
    internal class Method
    {
        public string Create(List<User> listUser, User usr)
        {
            if (UserValid(listUser, usr.Username))
            {
                listUser.Add(usr);
                return "User Success to created";
            }
            return "Create failure, Username already exists";
        }

        public void GetAllUser(List<User> listUser)
        {
            int i = 0;
            if (listUser.Count > 0)
            {
                foreach (User usr in listUser)
                {
                    i++;
                    Console.WriteLine("=======================");
                    Console.WriteLine("ID\t : " + i);
                    Console.WriteLine("Name\t : " + usr.FirstName + " " + usr.LastName);
                    Console.WriteLine("Username : " + usr.Username);
                    Console.WriteLine("Password : " + usr.Password);
                    Console.WriteLine("=======================");
                }
            }
            else
            {
                Console.WriteLine("User is Empty");
            }
        }

        public string Edit(List<User> listUser, User usr, int id)
        {
            listUser[id - 1].FirstName = usr.FirstName;
            listUser[id - 1].LastName = usr.LastName;
            listUser[id - 1].Username = usr.FirstName.Substring(0, 2) + usr.LastName.Substring(0, 2);
            listUser[id - 1].Password = usr.Password;
            return "User Success to Edited";
        }

        public string Delete(List<User> listUser, int id)
        {
            if (id <= listUser.Count)
            {
                listUser.RemoveAt(id - 1);
                return "User Success to Delete";
            }
            else
            {
                return "User not found";
            }
        }

        public bool UserValid(List<User> user, string usrName)
        {
            foreach (var usr in user)
            {
                if (usr.Username == usrName)
                {
                    return false;
                }
            }

            return true;
        }

        public string ValidationUsername(string username)
        {
            if (username.Length > 2)
            {
                return username;
            }
            else
            {
                Console.WriteLine("\nName has to be at least consisting 2 character or more");
                Console.Write("Input : ");
                username = Console.ReadLine();
                return ValidationUsername(username);
            }
        }

        public string ValidationPassword(string password)
        {
            if (password.Length > 7 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsNumber))
            {
                return password;
            }

            else
            {
                Console.WriteLine("\nPassword mush have at least 8 character \n with at least one Capital letter, at least one Lower case letter and at least one Number.");
                Console.Write("Password : ");
                password = Console.ReadLine();
                return ValidationPassword(password);
            }
        }
    }
}
