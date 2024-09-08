import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "the-new-css-reset";
import ProductClient from './components/ProductClient/ProductClient';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ProductClient/>
  </StrictMode>,
)
