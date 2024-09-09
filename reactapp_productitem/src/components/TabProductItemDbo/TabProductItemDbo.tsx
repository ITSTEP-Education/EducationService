import React, { FC, ReactHTMLElement, ReactNode, useEffect, useState } from 'react';
import { TableWrapper } from './TabProductItemDbo.styled';
import './TabProductItemDbo.css'
import { IProductItemDto } from '../ProductClient/ProductClient';

interface ProductsItemDto {
   productsDto: Array<IProductItemDto | null>
}

const Product = (product: IProductItemDto | null ): React.ReactElement => {

   const handleRow = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      console.log(e.currentTarget.getElementsByTagName('td')[1].textContent);
   }
''
   return (
      <tr onClick={handleRow}>
         <td>{product?.id}</td>
         <td>{product?.name}</td>
         <td>{product?.typeEngeeniring}</td>
      </tr>
   )
}

const TabProductItemDbo: FC<ProductsItemDto> = (props) => {

   const [productsDto, setProductsDto] = useState<Array<IProductItemDto | null>>([]);

   useEffect(() => {
      setProductsDto(props.productsDto);
   }, [props.productsDto]);

   let rowProducts = [];
   for(const product of productsDto){
      rowProducts.push(Product(product));
   }

   return (
      <TableWrapper id='tab-dbo'>
         <tr>
           <th>id</th>
           <th>Name</th>
           <th>Engineering</th>
         </tr>
         {rowProducts}
      </TableWrapper>
     );
}

export default TabProductItemDbo;
