using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.DTO;

namespace Todo.API
{
    internal class TodoAPI
    {

        private MobileServiceClient _client = new MobileServiceClient(Constants.ApplicationURL);
        private static object locker = new object();
        private static TodoAPI _instance;
        internal static TodoAPI Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(locker)
                    {
                        if (_instance == null)
                            _instance = new TodoAPI();
                    }
                }
                return _instance;
            }
        }


        private IMobileServiceTable<DTO.Todo> _todoTable;
        private TodoAPI()
        {
            _todoTable = _client.GetTable<DTO.Todo>();
        }


        public async Task<List<DTO.Todo>> GetaTodoListAsync()
        {
            return await _todoTable.ToListAsync().ConfigureAwait(false);
        }

        //public async Task<List<DTO.Todo>> GetaTodoListAsync(DeveloperDTO develop )
        //{
        //    return await _client
        //                    .InvokeApiAsync<DeveloperDTO, List<Todo>>("lillo", develop)
        //                    .ConfigureAwait(false);
        //}

        public async Task Add(DTO.Todo todo)
        {
            await _todoTable
                        .InsertAsync(todo)
                        .ConfigureAwait(false);
        }
    }
}
