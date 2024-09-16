import { useState, useEffect } from "react";

const useEngineerType = (_handleClientProps:()=>void ): [string, (e: React.FormEvent<HTMLElement>)=>void]=> {
    
    const [nameProduct, setNameProduct] = useState<string | null>(null);

    const handleNameProduct = (e: React.FormEvent<HTMLElement>): void => {
        e.preventDefault();
  
        setNameProduct(e.currentTarget.getElementsByTagName('td')[2].textContent);
        _handleClientProps();
    };

    useEffect(() => {handleNameProduct}, []);

    return [nameProduct != null? nameProduct : 'none', handleNameProduct];
}

export default useEngineerType;