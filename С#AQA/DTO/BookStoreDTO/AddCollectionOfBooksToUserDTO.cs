using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.BookStoreDTO
{
    public record AddCollectionOfBooksToUserDTO(
        string UserId,
        List<CollectionOfIsbnsDTO> CollectionOfIsbns 
    );
}
// Баг DTO названо на уроке Books, а demoqa ждёт collectionOfIsbns поэтому падал тест AddBookToUserAsync