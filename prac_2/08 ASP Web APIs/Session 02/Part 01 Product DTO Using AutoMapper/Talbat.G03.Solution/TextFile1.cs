#region p1
// p1.1 create Talabat.API\DTO
// p1.1 create Talabat.API\DTO\ProductToReturnDTO
// p1.1 go to Talabat.API\DTO\ProductToReturnDTO

// - DTO: data transefer object
// - as this mean : that is the object that will transefer data from database
//   to frontend framework(from server side to client side) as in this case when we get data,
//   or from client side to server side (post data)

// - as the frondend dev will use this class for visualizing data
//   in better way than it come from database like:
//   when it come like nstead object we will convert(mapping) it flat objects
// - this class is the same to viewModel in MVC, so we will use mapping


// - in API projects we use only controller(endpoints) to get data(GET)
//   and we don't need to add data(POST)
// - so we can create dashboard MVC project connect it with the same db
//   and make controller to add data(POST)
#endregion