import React, { FC, useEffect, useState } from 'react';
import axios from 'axios';
import { TableWrapper } from './TabProductItemDto.styled';
import './TabProductItemDto.css'

interface ITabProductItemDto {
   isTableLoad: boolean | false,
   _handleNameProduct: (e: React.FormEvent<HTMLElement>) => void,
   _handleEngineerType: (e: React.FormEvent<HTMLElement>) => void,
}

interface IProductItemDto{
   id: number,
   name: string,
   typeEngeeniring: string,
}

const Product = (product: IProductItemDto | null,  
   handleNameProduct: (e: React.FormEvent<HTMLElement>) => void,
   handleEngineerType: (e: React.FormEvent<HTMLElement>) => void): React.ReactElement => {

   return (
      <tr onClick={(e) => {handleNameProduct(e), handleEngineerType(e)}}>
         <td>{product?.id}</td>
         <td>{product?.name}</td>
         <td>{product?.typeEngeeniring}</td>
      </tr>
   )
}

const TabProductItemDto: FC<ITabProductItemDto> = (props) => {

   if (!props.isTableLoad) return;

   const [productsItemDto, setProductsItemDto] = useState<Array<IProductItemDto | null>>([]);

   const productsDto = axios.create({
      baseURL: 'https://localhost:7296/api/ProductItem',
      method: 'get',
      responseType: 'json',
   });

   useEffect(() => {
       
      productsDto.get('all-productitems-dto').
      then((responce) => {
         setProductsItemDto(responce.data);
         for(let product of productsItemDto){
            console.log(product);
         }       
      }).
      catch((error) => {
         console.log('error:', error)
      });
   }, []);

   let rowProducts = [];
   for(const product of productsItemDto){
      rowProducts.push(Product(product, props._handleNameProduct, props._handleEngineerType));
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

export default TabProductItemDto;
