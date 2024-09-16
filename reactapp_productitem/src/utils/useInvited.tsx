import { useState, useEffect } from "react";


const useInvited = (_handleClientProps:()=>void): [boolean, (e: React.FormEvent<HTMLElement>)=>void] => {
    const [isInvited, setIsInvited] = useState<boolean>(true);

    const handleInvited = (e: React.FormEvent<HTMLElement>): void => {
        e.preventDefault();
  
        setIsInvited(e.currentTarget.textContent?.toLocaleLowerCase() == 'yes');
        _handleClientProps();
    };

    useEffect(() => {handleInvited}, []);

    return [isInvited, handleInvited];
}
export default useInvited;