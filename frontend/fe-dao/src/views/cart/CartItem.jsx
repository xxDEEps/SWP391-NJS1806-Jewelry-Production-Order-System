import FirebaseImage from '@/components/custom/fire-base-image';
import QuantityButton from '@/components/custom/quantity-button';
import { Trash2 } from 'lucide-react';
import React, { useState } from 'react';

const CartItem = ({ item, onRemove}) => {

  const {totalPrice, setTotalPrice} = useState(item.price * item?.quantity)
  const {itemQuantity, setItemQuantity} = useState(item?.quantity)

  

  

  return (
    <div className="flex justify-between mb-4">

      <div className="flex align-top space-x-6">

        <div className='image-wrapper h-36 aspect-1 overflow-hidden relative '>
                <FirebaseImage path="products/thumbnails/bracelet.png" alt="bracelet"></FirebaseImage>
        </div>

        <div className='flex flex-col justify-between'>
            <span className="font-medium block text-lg ">{item.productName}</span>
            <span className="text-gray-600 text-lg italic ml-2 mb-6">{item.metalName} - {item.gemstoneName} - {item.size}</span>
            <QuantityButton chosenQuantity={item?.quantity + 1} stock={item.stockQuantity} onValueChange={setItemQuantity}></QuantityButton>
        </div>

      </div>

      <div className="flex align-top space-x-6">
        <div>
            <span className="text-gray-600 mr-4 text-lg"> {item.price} VND</span>
        </div>
        
            <button
                    className=" hover:text-stone-800 text-gray-400 border-none px-4 py-2  cursor-pointer "
                    onClick={() => onRemove(id)}
            >
            <Trash2 />
            </button>
      </div>
    </div>
  );
};

export default CartItem;
