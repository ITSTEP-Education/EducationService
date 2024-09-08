import React, { FC } from 'react';
import { TableWrapper } from './TabProductItemDbo.styled';
import './TabProductItemDbo.css'

interface TabProductItemDboProps {}

const TabProductItemDbo: FC<TabProductItemDboProps> = () => {

   const rowData: React.ReactElement = 
   <tr>
      <td>1</td>
      <td>c#</td>
      <td>back-end</td>
   </tr>


   return (
      <TableWrapper id='tab-dbo'>
         <tr>
           <th>id</th>
           <th>Name</th>
           <th>Engineering</th>
         </tr>
         {rowData}
      </TableWrapper>
     );
}

export default TabProductItemDbo;
