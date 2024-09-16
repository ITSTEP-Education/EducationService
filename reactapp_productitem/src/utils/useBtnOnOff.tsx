import { useState, useEffect } from "react";


const useBtnOnOff = (flag: boolean): [boolean, (e: React.FormEvent<HTMLElement>)=>void] => {
    const [isOnOff, setIsOnOff] = useState<boolean>(flag);

    const handleIsOnOff = (e: React.FormEvent<HTMLElement>): void => {
        e.preventDefault();
  
        setIsOnOff(!isOnOff);
    };

    useEffect(() => {handleIsOnOff}, []);

    return [isOnOff, handleIsOnOff];
}
export default useBtnOnOff;